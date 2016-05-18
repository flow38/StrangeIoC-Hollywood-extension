using UnityEngine;

namespace strange.extensions.hollywood.impl.UI.Utils
{
    public interface IRectTransformWrapper
    {
        void SetRectTransformPosition(Vector2 position);

        Vector2 GetRectTransformPosition();

        void SetRectTransformSize(Vector2 size);

        Vector2 GetRectTransformSize();
    }
}