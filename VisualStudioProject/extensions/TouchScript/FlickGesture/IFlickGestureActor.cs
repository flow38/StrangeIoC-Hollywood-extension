using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.FlickGesture
{
    public interface IFlickGestureActor : IGestureListener
    {
        /// <summary>
        /// Player flick gesture is detected
        /// </summary>
        Signal<FlickGestureInfo> OnFlickGesture { get; }
    }
}