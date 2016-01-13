using falcy.strange.extensions.hollywood.api;
using strange.extensions.mediation.impl;
using UnityEngine;

namespace falcy.strange.extension.hollywood.impl
{
    public class Actor : View, IActor
    {
        /// <summary>
        /// Cached GameObject Transform component
        /// </summary>
        protected Transform MyTransform;

        protected override void Awake()
        {
            MyTransform = transform;
            base.Awake();
        }

        public Vector3 GetPosition()
        {
            return MyTransform.position;
        }

        public void SetPosition(Vector3 pos)
        {
            MyTransform.position = pos;
        }
    }
}
