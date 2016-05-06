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
        private IDirector _director;

        #region IActor
        public virtual string Name
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
        /// <summary>
        /// Look at any existing IActor instance on actor's gameobject and
        /// return first found IDirector instance implementing T.
        /// </summary>
        /// TODO create an integration test
        /// <typeparam name="T"></typeparam>
        /// <param name="lookAtChildren"></param>
        /// <returns></returns>
        public virtual T GetDirectorComponent<T>(bool lookAtChildren = false) where T : IDirector
        {
            T foundDirector = default(T);

            IActor[] othersActor = GetComponents<IActor>();
            foundDirector = searchDirectorComponent<T>(othersActor);

            if (foundDirector == null && lookAtChildren)
            {
                othersActor = GetComponentsInChildren<IActor>();
                foundDirector = searchDirectorComponent<T>(othersActor);
            }

            return foundDirector;
        }

        public virtual IDirector Director
        {
            get { return _director; }
            set {
                if (_director != null)
                    throw new HollywoodException("Director property is already set !!", HollywoodExceptionType.DirectorIsAlreadyDefine);
                _director = value;
            }
        }

        public virtual Vector3 GetPosition(bool inWorldSpace = true)
        {
            if (inWorldSpace)
                return MyTransform.position;
            else
                return MyTransform.localPosition;
        }

        public virtual void SetPosition(Vector3 pos, bool inWorldSpace = true)
        {
            if (inWorldSpace)
                MyTransform.position = pos;
            else
                MyTransform.localPosition = pos;
        }

        public virtual void AddChild(IActor child)
        {
            var actor = child as Actor;
            actor.MyTransform.parent = MyTransform;
        }

        #endregion


        #region IUnityActor
        public virtual Material Material()
        {
            return MyMaterial;
        }

        public virtual Transform Transform()
        {
            return MyTransform;
        }

        public virtual GameObject GameObject()
        {
            return MyGameObject;
        }

        /// <summary>
        /// Cached Monobehavior component accessors
        /// </summary>
        public virtual void CachedGameObjectShortcuts()
        {
            MyTransform = transform;
            MyGameObject = gameObject;
            MyRenderer = GetComponent<Renderer>();
            if (MyRenderer != null)
                MyMaterial = MyRenderer.material;
        }

        #endregion

        #region MonoBehavior

        protected override void Awake()
        {
            CachedGameObjectShortcuts();
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

        #region private
        /// <summary>
        /// Browse throught an IActor array and test each actor's IDirector instance to
        /// find and return first found T instance.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="othersActor"></param>
        /// <returns></returns>
        private T searchDirectorComponent<T>(IActor[] othersActor) where T : IDirector
        {
            var _l = othersActor.Length;
            for (int i = 0; i < _l; i++)
            {
                if (othersActor[i] != this && othersActor[i].Director != null && othersActor[i].Director is T)
                {
                    return (T)othersActor[i].Director;
                }
            }

            return default(T);
        }
        #endregion
    }
}