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

using falcy.strange.extension.hollywood.api;
using falcy.strange.extensions.hollywood.impl;
using strange.extensions.command.api;
using strange.extensions.command.impl;
using strange.extensions.context.impl;
using strange.extensions.mediation.api;

/// <summary>
///  TODO : replace crossContext event dispatcher by a Signal<String> 
/// 
/// </summary>
namespace falcy.strange.extension.hollywood.impl
{
    public class HollywoodContext : MVCSContext
    {
        // Unbind the default EventCommandBinder and rebind the SignalCommandBinder
        protected override void addCoreComponents()
        {
            base.addCoreComponents();
            injectionBinder.Unbind<ICommandBinder>();
            injectionBinder.Bind<ICommandBinder>().To<SignalCommandBinder>().ToSingleton();

            //Replace Mediation binding by Director binding
            injectionBinder.Unbind<IMediationBinder>();
            injectionBinder.Bind<IDirectorBinder>().To<DirectorBinder>();
        }
    }
}