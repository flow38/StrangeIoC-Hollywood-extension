using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.PressGesture
{
    public interface IPressGestureActor : IGestureListener
    {
        /// <summary>
        /// Player flick gesture is detected
        /// </summary>
        Signal<bool, Vector3> OnPressed { get; }

    }
}