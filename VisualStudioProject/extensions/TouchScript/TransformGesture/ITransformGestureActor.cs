using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    public interface ITransformGestureActor : IGestureListener
    {
        Signal<TransformInfos> OnTransformed { get; }

        Signal<TransformInfos> OnStarted { get; }

        Signal<TransformInfos> OnCancelled { get; }

        Signal<TransformInfos> OnCompleted { get; }

        Signal<TransformInfos> OnStateChanged { get; }

        /// <summary>
        /// Get & Set TransformGesture component Min point distance
        /// </summary>
        float MinScreenPointsDistance { get; set; }

        /// <summary>
        /// Get & Set TransformGesture component ScreenTransformThreshold  
        /// </summary>
        float ScreenTransformThreshold { get; set; }
    }
}