using System;
using strange.extensions.signal.api;

namespace strange.extensions.hollywood.api
{
    public interface ISignal : IBaseSignal
    {
        void Dispatch();

        void AddListener(Action callback);

        void RemoveListener(Action callback);

        void AddOnce(Action callback);
    }
}