using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.ReleaseGesture
{
    public interface IReleaseGestureActor : IGestureListener
    {
        /// <summary>
        /// Player flick gesture is detected
        /// </summary>
        Signal<Vector3> OnReleased { get; }

        void CancelRelease();

    }
}