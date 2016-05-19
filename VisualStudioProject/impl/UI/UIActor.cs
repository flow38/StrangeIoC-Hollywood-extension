using strange.extensions.hollywood.impl.UI.Utils;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIActor : Actor, IUIActor, IRectTransformWrapper
    {
        private RectTransform _rectTransform;
        private IRectTransformWrapper _rectTransformWrapper;

        public RectTransform RectTransform
        {
            get { return _rectTransform; }
        }

        protected override void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _rectTransformWrapper = new RectTransformUtils(_rectTransform);

            base.Awake();
        }
        
        #region IRectTransformWrapper delegation pattern
        public void SetRectTransformPosition(Vector2 position)
        {
            _rectTransformWrapper.SetRectTransformPosition(position);
        }

        public Vector2 GetRectTransformPosition()
        {
            return _rectTransformWrapper.GetRectTransformPosition();
        }

        public void SetRectTransformSize(Vector2 size)
        {
            _rectTransformWrapper.SetRectTransformSize(size);
        }

        public Vector2 GetRectTransformSize()
        {
            return _rectTransformWrapper.GetRectTransformSize();
        }

        #endregion

    }
}
