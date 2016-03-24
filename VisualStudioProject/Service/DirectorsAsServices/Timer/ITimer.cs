using System;
using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.Service.DirectorsAsServices.Timer
{
    /// <summary>
    /// An ITimer is basically a signal dispatcher that will invoke suscribers callback at a given period of time
    /// </summary>
    public interface ITimer : IService
    {
        void Suscribe(Action callback);

        void Unsuscribe(Action callback);

        void StartTimer();
        void PauseTime();
        void StopTimer();
        /// <summary>
        /// Stop timer and change its time periode before start it
        /// </summary>
        /// <param name="timePeriod"></param>
        void ChangeTimePeriod(float timePeriod);
    }
}