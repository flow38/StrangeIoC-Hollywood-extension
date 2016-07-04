using strange.extensions.hollywood.api;
using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.Service.DirectorsAsServices.Timer
{
    public interface ITimerActor : IActor
    {
        Signal OnUpdate { get; set; }
        void StartTimer();
        void PauseTime();
        void StopTimer();
        /// <summary>
        /// Pause timer and change its time periode before release pause
        /// </summary>
        /// <param name="timePeriod"></param>
        void ChangeTimePeriod(float timePeriod);
    }
}