using System;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI.Utils
{
    public class RectTransformUtils : IRectTransformWrapper
    {

        RectTransform _parentRectTransform;
        RectTransform _selfRectTransform;

        public RectTransformUtils(RectTransform selfRectTransform)
        {
            _selfRectTransform = selfRectTransform;
            lookForParentRectTransform();
        }

        #region IRectTransformWrapper

        public void SetRectTransformPosition(Vector2 position)
        {
            lookForParentRectTransform();
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

            _selfRectTransform.anchoredPosition = position;
        }

        public Vector2 GetRectTransformPosition()
        {
            lookForParentRectTransform();
            Vector2 position = _selfRectTransform.anchoredPosition;
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

        public Vector2 GetRectTransformSize()
        {
            lookForParentRectTransform();
            Vector2 size = _selfRectTransform.sizeDelta;

            if (_parentRectTransform.rect.width != 0 && _parentRectTransform.rect.height != 0)
            {
                size.x = size.x / _parentRectTransform.rect.width;
                size.y = size.y / _parentRectTransform.rect.height;
            }
            else
            {
                size.x = size.x / Screen.width;
                size.y = size.y / Screen.height;
            }

            return size;
        }

        public void SetRectTransformSize(Vector2 size)
        {
            lookForParentRectTransform();
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

            _selfRectTransform.sizeDelta = size;
        }

        #endregion

        private void lookForParentRectTransform()
        {
            if (_parentRectTransform == null && _selfRectTransform.parent != null)
                _parentRectTransform = _selfRectTransform.parent.GetComponentInParent<RectTransform>();
        }
    }
}
