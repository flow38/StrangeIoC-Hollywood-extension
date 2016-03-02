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

using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.api
{
    public interface IActor : IHollywoodView
    {

        /// <summary>
        /// Get position
        /// </summary>
        /// <param name="inWorldSpace"></param>
        /// <returns></returns>
        Vector3 GetPosition(bool inWorldSpace = true);

        /// <summary>
        ///  Set position 
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="inWorldSpace"></param>
        void SetPosition(Vector3 pos, bool inWorldSpace = true);

        void AddChild(IActor child);

        string  Name { get; set; }

        Signal StartSignal { get; set; }
    }
}