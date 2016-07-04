/*
 * Copyright 2016 Florent Falcy.
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
using strange.extensions.hollywood.api;
using strange.extensions.injector.api;
using strange.extensions.injector.impl;

namespace strange.extensions.hollywood.impl
{
    public abstract class BaseDirector<T> : IDirector
    {

        /// <summary>
        /// Internal accessor to actor instance, allow more accurate interface
        /// casting than IDirector's "actor" property.
        /// </summary>
        protected T MyActor
        {
            get { return (T)Actor; }
        }

        [Inject(HollywoodSignals.Start)]
        public ISignal StartSignal { get; set; }

        [Inject(HollywoodSignals.WarmUp)]
        public ISignal WarmupSignal { get; set; }

        [Inject]
        public IHollywoodContextView ContextView { get; set; }

        [Inject]
        public IInjectionBinder _injectionBinder { get; set; }


        [PostConstruct]
        public virtual void PostConstruct()
        {
            if (ContextView.hasAlreadyStart())
            {
                WarmUp();
                //Dans cette situation on n'execute le StartUp que sur la fin sur le onRegister pour permettre aux implementations
                // de StartUp de faire reference à l'acteur du directeur.
            }
            else
            {
                WarmupSignal.AddOnce(WarmUp);
                StartSignal.AddOnce(Start);
            }
        }

        /// <summary>
        /// Implement this method to get references to other service or Director instance via Director's injected
        /// context's IInjectionBinder instance  or via actor GetDirectorComponent() method...
        /// </summary>
        protected virtual void WarmUp()
        {
            //throw new System.NotImplementedException();
        }

        /// <summary>
        /// Implement this method to realy start your instance job, make safely call to other directors and services.
        /// </summary>
        protected virtual void Start()
        {
            //throw new System.NotImplementedException();
        }


        /// <summary>
        ///     Fires directly after creation and before injection
        /// </summary>
        public virtual void PreRegister()
        {
        }


        /// <summary>
        ///     Fires after all injections satisifed.
        ///     Override and place your Actor/Director relationship initialization code here
        /// </summary>
        public virtual void OnRegister(IActor actor)
        {
            ///Beware, never try here to access other Director via Actor.GetDirectorComponent<T>() method, we're not sur
            /// other GameObject actor component have been awake (and bind to a Director) or not
            ///Example :  myItemDirector = Actor.GetDirectorComponent<IItemDirector>();
            Actor = actor;
            if (ContextView.hasAlreadyStart())
            {
                Start();
            }
        }


        /// <summary>
        ///     Fires on removal of view.
        ///     Deprecated : Override and place your Actor/Director relationship cleanup code here
        ///     => RelationShip with actor is only based on signal listening, which are clean by actor's onDestroy()
        /// </summary>
        public virtual void OnRemove()
        {
            Actor = null;
        }

        /// <summary>
        /// Public accessor for actor instance
        /// </summary>
        public IActor Actor { get; set; }
    }
}