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
using falcy.strange.extensions.hollywood.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.api;
using strange.extensions.context.impl;
using strange.extensions.mediation.api;
using UnityEngine;

/// <summary>
///  TODO : replace crossContext event dispatcher by a Signal<String> 
/// 
/// </summary>

namespace falcy.strange.extension.hollywood.impl
{
    public class HollywoodMVCSContext : MVCSContext
    {
        public HollywoodMVCSContext(MonoBehaviour view) : base(view)
        {
        }

        public HollywoodMVCSContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

            //Replace Mediation binding by Director binding
            injectionBinder.Unbind<IMediationBinder>();
            injectionBinder.Bind<IMediationBinder>().To<DirectorBinder>();
        }

        public override void AddView(object view)
        {
            if (mediationBinder != null)
            {
                mediationBinder.Trigger(MediationEvent.AWAKE, (IView) view);
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
            //Ensure that all Views underneath the ContextView are triggered
            var contView = (contextView as GameObject).GetComponent<ContextView>();
            if (contView == null)
            {
                Console.WriteLine("ccccc");
            }
            mediationBinder.Trigger(MediationEvent.AWAKE, contView);
        }
    }
}