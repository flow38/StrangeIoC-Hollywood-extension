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
    }
}