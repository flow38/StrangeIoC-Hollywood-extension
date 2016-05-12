using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIActor : Actor, IUIActor
    {
        private RectTransform _rectTransform;

        public RectTransform RectTransform
        {
            get { return _rectTransform; }
        }

        protected override void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();

            base.Awake();
        }
    }
}
