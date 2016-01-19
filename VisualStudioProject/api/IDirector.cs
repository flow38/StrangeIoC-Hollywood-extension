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

namespace strange.extensions.hollywood.api
{
    public interface IDirector
    {
        /// <summary>
        /// IActor the IDirector instance is responsible for
        /// </summary>
        IActor Actor { get; set; }

        /// This method fires immediately after instantiation, but before injection.
        /// Override to handle anything that needs to happen prior to injection.
        void PreRegister();

        /// This method fires immediately after injection.
        /// Override to perform the actions you might normally perform in a constructor.
        void OnRegister(IActor actor);

        /// This method fires just before Director's actor instance will be destroyed.
        /// Override to clean up any listeners, or anything else that might keep the Actor/Director pair from being garbage collected.
        void OnRemove();
    }
}