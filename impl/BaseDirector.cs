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
using falcy.strange.extensions.hollywood.api;

namespace falcy.strange.extensions.hollywood.impl
{
    public class BaseDirector : IDirector
    {
        /// <summary>
        ///     Fires directly after creation and before injection
        /// </summary>
        public virtual void PreRegister()
        {
        }


        /// <summary>
        ///     Fires after all injections satisifed.
        ///     Override and place your initialization code here
        ///     ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        /// </summary>
        public virtual void OnRegister(IActor actor)
        {
            Actor = actor;
        }

        /// <summary>
        ///     Fires on removal of view.
        ///     Override and place your cleanup code here
        ///     ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        /// </summary>
        public virtual void OnRemove()
        {
            Actor = null;
        }

        public IActor Actor { get; set; }
    }
}