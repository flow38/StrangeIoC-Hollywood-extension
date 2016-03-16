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
using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.impl
{
    public class Actor : View, IActor
    {
        /// <summary>
        ///     Cached GameObject Transform component
        /// </summary>
        protected Transform MyTransform;

        protected GameObject MyGameObject;

        private Signal<MonoBehaviorEvent> _monoBehaviorSignal;

        #region getter/setter
        public string Name
        {
            get {
                return MyGameObject.name;
            }
            set {
                MyGameObject.name = value;
            }
        }

        public Signal<MonoBehaviorEvent> MonoBehaviorSignal
        {
            get { return _monoBehaviorSignal; }
            set { _monoBehaviorSignal = value; }
        }

        #endregion

        public Vector3 GetPosition(bool inWorldSpace = true)
        {
            if (inWorldSpace)
                return MyTransform.position;
            else
                return MyTransform.localPosition;
        }

        public void SetPosition(Vector3 pos, bool inWorldSpace = true)
        {
            if (inWorldSpace)
                MyTransform.position = pos;
            else
                MyTransform.localPosition = pos;
        }

        public void AddChild(IActor child)
        {
            var actor = child as Actor;
            actor.MyTransform.parent = MyTransform;
        }

        protected override void Awake()
        {
            MyTransform = transform;
            MyGameObject = gameObject;
            _monoBehaviorSignal = new Signal<MonoBehaviorEvent>();
            base.Awake();
        }

        public void Start()
        {
            base.Start();
            _monoBehaviorSignal.Dispatch(MonoBehaviorEvent.Start);
            ///
            /// You should never, never,  NEVER put any code here, instead use IDirector::Start method
            /// 
        }

        public void OnDestroy()
        {
            _monoBehaviorSignal.RemoveAllListeners();
        }
    }
}