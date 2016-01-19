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
using strange.extensions.mediation.impl;
using UnityEngine;

namespace strange.extensions.hollywood.impl
{
    public class Actor : View, IActor
    {
        /// <summary>
        ///     Cached GameObject Transform component
        /// </summary>
        protected Transform MyTransform;

        public Vector3 GetPosition()
        {
            return MyTransform.position;
        }

        public void SetPosition(Vector3 pos)
        {
            MyTransform.position = pos;
        }

        protected override void Awake()
        {
            MyTransform = transform;
            base.Awake();
        }
    }
}