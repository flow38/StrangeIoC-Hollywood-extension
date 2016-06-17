using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.PressGesture
{
    public interface IPressGestureActor : IGestureListener
    {
        /// <summary>
        /// Press gesture istriggered
        /// </summary>
        Signal<Vector3> OnPressed { get; }

    }
}