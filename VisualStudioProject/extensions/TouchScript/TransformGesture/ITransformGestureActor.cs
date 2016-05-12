using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    public interface ITransformGestureActor : IGestureListener
    {
        /// <summary>
        /// Player flick gesture is detected
        /// </summary>
        Signal<TransformGestureInfos> OnTransformGesture { get; }
    }
}