using falcy.strange.extensions.hollywood.api;
using UnityEngine;

namespace falcy.strange.extensions.hollywood.impl
{
    public class Actor : MonoBehaviour, IActor
    {
        /// <summary>
        /// Cached GameObject Transform component
        /// </summary>
        protected Transform MyTransform;
        
        public void Awake()
        {
            MyTransform = transform;
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
