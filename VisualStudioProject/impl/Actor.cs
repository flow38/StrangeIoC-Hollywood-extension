﻿/*
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
    public class Actor : View, IUnityActor
    {
        /// <summary>
        ///     Cached GameObject Transform component
        /// </summary>
        protected Transform MyTransform;

        protected GameObject MyGameObject;

        protected Material MyMaterial;

        protected Renderer MyRenderer;

        private Signal<MonoBehaviorEvent> _monoBehaviorSignal;

        #region IActor
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

        #region IUnityActor
        public Material Material()
        {
            return MyMaterial;
        }

        public Transform Transform()
        {
            return MyTransform;
        }

        public GameObject GameObject()
        {
            return MyGameObject;
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

        #endregion


        #region MonoBehavior

        protected override void Awake()
        {
            MyTransform = transform;
            MyGameObject = gameObject;
            MyRenderer = GetComponent<Renderer>();
            if (MyRenderer != null)
                MyMaterial = MyRenderer.material;
            _monoBehaviorSignal = new Signal<MonoBehaviorEvent>();
            base.Awake();
        }

        protected override void Start()
        {
            base.Start();
            _monoBehaviorSignal.Dispatch(MonoBehaviorEvent.Start);
            ///
            /// You should never, never,  NEVER put any code here, instead use IDirector::Start method
            /// 
        }

        protected override void OnDestroy()
        {
            _monoBehaviorSignal.RemoveAllListeners();
            //todo pour le moment les acteur sont destroy par le context parent. Dans l'idéal les vue devrait se detruire toute seules sur
            //via un evenement Monobehavior , du coups pour le moment on commente base.OnDestroy(); pour ne pas faire doublon
            //base.OnDestroy();
        }
        #endregion
    }
}