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
using strange.extensions.signal.api;

namespace strange.extensions.hollywood.impl
{
    public class BaseDirector<T> : IDirector
    {
        
        /// <summary>
        /// Internal accessor to actor instance, allow more accurate interface
        /// casting than IDirector's "actor" property.
        /// </summary>
        protected T MyActor;

        [Inject]
        public IStartDirectorsSignal StartDirectors{ get; set; }

        
        public BaseDirector()
        {
           
        }

        [PostConstruct]
        public void PostConstruct()
        {
            StartDirectors.AddOnce(OnStart);
        }


        /// <summary>
        ///     Fires directly after creation and before injection
        /// </summary>
        public virtual void PreRegister()
        {
        }


        /// <summary>
        ///     Fires after all injections satisifed.
        /// </summary>
        public void OnRegister(IActor actor)
        {
            Actor = actor;
            MyActor = (T)actor;
        }

        /// <summary>
        ///     Fire on actor's OnStart monobehavior "event"
        ///     Override and place your initialization code here
        /// </summary>
        public virtual void OnStart(IBaseSignal baseSignal, object[] objects)
        {
            var t = 1;
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

        public virtual void OnContextStart(IBaseSignal baseSignal, object[] objects)
        {
        }

        /// <summary>
        /// Public accessor for actor instance
        /// </summary>
        public IActor Actor { get; set; }
    }
}