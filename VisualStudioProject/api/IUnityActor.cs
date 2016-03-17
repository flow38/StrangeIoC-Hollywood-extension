﻿using UnityEngine;

namespace strange.extensions.hollywood.api
{
    /// <summary>
    /// Interface to handle all usecase where method must return or process a Unity Class object
    /// </summary>
    public interface IUnityActor : IActor
    {
        Material Material();

        Transform Transform();
    }
}