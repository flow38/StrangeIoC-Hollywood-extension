﻿using strange.extensions.signal.api;

namespace strange.extensions.hollywood.api
{
    /// <summary>
    /// IService is a Service Class as Domain Driven Developement define it :
    /// - "When an operation does not conceptually belong to any object. Following the natural contours of the problem, you can implement these operations in services." (Wikipedia)
    /// - https://en.wikipedia.org/wiki/Domain-driven_design
    /// 
    /// In Unity context, IService is NEVER a MonoBehavior subclass.
    /// If a service need to use Unity API, you must create an Actor & Director instead or inject to the service all needed Director that
    /// will perform via their Actors the Unnity API calls.
    /// </summary>
    public interface IService
    {

    }
}