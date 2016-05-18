using System;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI.Utils
{
    public  class RectTransformUtils : IRectTransformWrapper
    {

        RectTransform _parentRectTransform;
        RectTransform _selfRectTransform;

        public RectTransformUtils(RectTransform selfRectTransform)
        {
            _selfRectTransform = selfRectTransform;
            _parentRectTransform = selfRectTransform.parent.GetComponentInParent<RectTransform>();
        }

        #region IRectTransformWrapper

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

            _selfRectTransform.anchoredPosition = position;
        }

        public Vector2 GetRectTransformPosition()
        {
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

            _selfRectTransform.sizeDelta = size;
        }

        public Vector2 GetRectTransformSize()
        {
            Vector2 size = _selfRectTransform.sizeDelta;
            size.x = size.x / Screen.width;
            size.y = size.y / Screen.height;

            return size;
        }
        #endregion
    }
}
