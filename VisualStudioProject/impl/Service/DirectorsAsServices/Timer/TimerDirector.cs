using System;
using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.Service.DirectorsAsServices.Timer
{
    public class TimerDirector : Director<ITimerActor>, ITimer
    {
        public void Suscribe(Action callback)
        {
            MyActor.OnUpdate.AddListener(callback);
        }

        public void Unsuscribe(Action callback)
        {
            MyActor.OnUpdate.RemoveListener(callback);
        }

        public void StartTimer()
        {
            MyActor.StartTimer();
        }

        public void PauseTime()
        {
            MyActor.PauseTime();
        }

        public void StopTimer()
        {
            MyActor.StopTimer();
        }

        public void ChangeTimePeriod(float timePeriod)
        {
            MyActor.ChangeTimePeriod(timePeriod);
        }
    }
}