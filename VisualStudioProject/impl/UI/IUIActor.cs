using strange.extensions.hollywood.api;
using UnityEngine;

namespace strange.extensions.hollywood.impl.UI
{
    public interface IUIActor : IActor
    {
        RectTransform RectTransform { get; }

        /// <summary>
        /// Set normalised Actor position relative to parent pivot point
        /// </summary>
        /// <param name="position">Percent Actor position relative to parent pivot point<</param>
        void SetRectTransformPosition(Vector2 position);

        /// <summary>
        /// Get normalised Actor position relative to parent pivot point
        /// </summary>
        /// <returns>Percent Actor position relative to parent pivot point</returns>
        Vector2 GetRectTransformPosition();

        /// <summary>
        /// Set normalised Actor size relative to parent size
        /// </summary>
        /// <param name="size">Percent Actor size relative to parent size</param>
        void SetRectTransformSize(Vector2 size);

        /// <summary>
        ///  </summary>
        /// <returns>Percent Actor size relative to parent size</returns>
        Vector2 GetRectTransformSize();

    }
}