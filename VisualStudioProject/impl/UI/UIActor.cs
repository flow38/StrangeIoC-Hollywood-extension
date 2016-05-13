using System;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    [RequireComponent(typeof(RectTransform))]
    public abstract class UIActor : Actor, IUIActor
    {
        private RectTransform _rectTransform;
        private RectTransform _parentRectTransform;

        public RectTransform RectTransform
        {
            get { return _rectTransform; }
        }

        public void SetRectTransformPosition(Vector2 position)
        {
            //Convert percent values to pixel values
            if (_parentRectTransform.rect.width != 0 && _parentRectTransform.rect.height != 0)
            {
                position.x = position.x * _parentRectTransform.rect.width;
                position.y = position.y * _parentRectTransform.rect.height;
            }
            else
            {
                position.x = position.x * Screen.width;
                position.y = position.y * Screen.height;
            }

            _rectTransform.anchoredPosition = position;
        }

        public Vector2 GetRectTransformPosition()
        {
            Vector2 position = _rectTransform.anchoredPosition;
            if (_parentRectTransform.rect.width != 0 && _parentRectTransform.rect.height != 0)
            {
                position.x = position.x / _parentRectTransform.rect.width;
                position.y = position.y / _parentRectTransform.rect.height;
            }
            else
            {
                position.x = position.x / Screen.width;
                position.y = position.y / Screen.height;
            }

            return position;
        }

        public void SetRectTransformSize(Vector2 size)
        {
            if (size.x < 0 || size.y < 0)
            {
                throw (new Exception("size vector x & y properties cannot be negative (mean nothing about a width & height percent valeur)"));
            }

            //Convert percent values to pixel values
            if (_parentRectTransform.rect.width != 0 && _parentRectTransform.rect.height != 0)
            {
                size.x = _parentRectTransform.rect.width * size.x - _parentRectTransform.rect.width;
                size.y = _parentRectTransform.rect.height * size.y - _parentRectTransform.rect.height;
            }
            else
            {
                size.x = Screen.width * size.x - Screen.width;
                size.y = Screen.height * size.y - Screen.height;
            }

            _rectTransform.sizeDelta = size;
        }

        public Vector2 GetRectTransformSize()
        {
            Vector2 size = _rectTransform.sizeDelta;
            size.x = size.x / Screen.width;
            size.y = size.y / Screen.height;

            return size;
        }


        protected override void Awake()
        {
            _rectTransform = GetComponent<RectTransform>();
            _parentRectTransform = transform.parent.GetComponentInParent<RectTransform>();

            base.Awake();
        }

    }
}
