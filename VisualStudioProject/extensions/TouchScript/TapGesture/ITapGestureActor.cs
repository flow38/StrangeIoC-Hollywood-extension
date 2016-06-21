using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.TapGesture
{
    public interface ITapGestureActor : IGestureListener
    {
        /// <summary>
        /// trigger when a tap is detected , Vector3 is tap position
        /// </summary>
        Signal<Vector3> OnTapped { get; set; }

    }
}