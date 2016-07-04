/*
 * Copyright 2016 Florent Falcy
 *
 *	Licensed under the Apache License, Version 2.0 (the "License");
 *	you may not use this file except in compliance with the License.
 *	You may obtain a copy of the License at
 *
 *		http://www.apache.org/licenses/LICENSE-2.0
 *
 *		Unless required by applicable law or agreed to in writing, software
 *		distributed under the License is distributed on an "AS IS" BASIS,
 *		WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 *		See the License for the specific language governing permissions and
 *		limitations under the License.
 */

using System;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl.Command;
using strange.extensions.hollywood.impl.IntegrationTest;
using strange.extensions.hollywood.impl.UI.Panel;
using strange.extensions.injector.api;
using strange.extensions.mediation.api;
using UnityEngine;

/// <summary>
///  TODO : replace crossContext event dispatcher by a Signal<String> 
/// 
/// </summary>

namespace strange.extensions.hollywood.impl
{
    public class HollywoodMVCSContext : MVCSContext
    {
        protected LaunchAppSignal StartHollywood;
        protected IHollywoodContextView _hollywoodContextView;

        public HollywoodMVCSContext(MonoBehaviour view) : base(view, ContextStartupFlags.MANUAL_MAPPING)
        {
            _hollywoodContextView = view.GetComponent<IHollywoodContextView>();
            if (_hollywoodContextView == null)
                throw (new Exception("HollywoodMVCSContext constructor error, there's no IHollywoodContextView instance on context's view !!!"));
            Start();
        }

        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();

            //Replace Event to Command binding by a Signal to Command binding
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

            //Replace Mediation binding by Director binding
            injectionBinder.Unbind<IMediationBinder>();
            injectionBinder.Bind<IMediationBinder>().To<DirectorBinder>().ToSingleton();
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            //Bind context view (Hollywood services need to get it in order to known if context have already start
            injectionBinder.Bind<IHollywoodContextView>().To(_hollywoodContextView);

            //Build Context WarmUp &  StartUp Signals...
            injectionBinder.Bind<ISignal>().To<SimpleSignal>().ToName(HollywoodSignals.Start).ToSingleton();
            injectionBinder.Bind<ISignal>().To<SimpleSignal>().ToName(HollywoodSignals.WarmUp).ToSingleton();
            // and Set it to context view 
            _hollywoodContextView.StartDirectors = injectionBinder.GetInstance<ISignal>(HollywoodSignals.Start);
            _hollywoodContextView.WarmUpDirectors = injectionBinder.GetInstance<ISignal>(HollywoodSignals.WarmUp);
            //Actor/Director Binding
            mediationBinder.Bind<PanelActor>().To<PanelDirector>();

            //Map signal LaunchAppIsDoneSignal
            injectionBinder.Bind<LaunchAppIsDoneSignal>().ToSingleton();
        }

        public override void AddView(object view)
        {
            if (mediationBinder != null)
            {
                mediationBinder.Trigger(MediationEvent.AWAKE, (IView)view);
            }
            else
            {
                cacheView(view as MonoBehaviour);
            }
        }

        protected override void postBindings()
        {
            //It's possible for views to fire their Awake before bindings. This catches any early risers and attaches their Mediators.
            mediateViewCache();


            //Probleme avec le code ci dessous : il declenche la mediation sur tous les Actors trouvés dans la hierachie des enfant de la vue de context
            //Conséquence : le onRegister des Director associé vont être executé alors que le awake de l'actor correspondant ne s'est pas produit!!
            //=> Pose problème pour la mise en place de l'ecoute sur MonoBehaviorSignal de l'actor par le director, le signal étant alors null

            //Solution : on se contente d'injecter la vue de context et les actor enfants s'enregistrerons lors de leurs Awake..
            // A voir si ça tiend le coups... @todo
            //Ensure that all Views underneath the ContextView are triggered
            var contView = (contextView as GameObject).GetComponent<ContextView>();
            //mediationBinder.Trigger(MediationEvent.AWAKE, contView);
            injectionBinder.injector.Inject(contView, false);

            //Add AppLaunchIsDone command to launching app command sequence
            if (injectionBinder.GetBinding<LaunchAppSignal>() != null)
                commandBinder.GetBinding<LaunchAppSignal>().To<AppLaunchIsDone>();
            else
                commandBinder.Bind<LaunchAppSignal>().To<AppLaunchIsDone>();
        }

        /// Fires StartHollywood
		/// Whatever Command/Sequence you want to happen first should 
		/// be mapped to this event.
		public override void Launch()
        {
            if (injectionBinder.GetBinding<LaunchAppSignal>() == null)
            {
                throw (
                    new HollywoodException(
                        "You must bind LaunchAppSignal Class to a command in order to boot your game, or set autoStartup to false !",
                        HollywoodExceptionType.LaunchAppSignalIsNotBindToACommand
                        )
                    );
            }

            injectionBinder.GetInstance<LaunchAppSignal>().Dispatch();
        }
    }
}