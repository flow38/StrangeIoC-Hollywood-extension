using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.Service.DirectorsAsServices.Timer
{
    public class TimerActor : Actor, ITimerActor
    {
        public Signal OnUpdate { get; set; }
        private float _lastFrametime;
        private float _deltaTime;

        [SerializeField]
        private float _timePeriod;

        public TimerActor()
        {
            OnUpdate = new Signal();
        }

        public void Update()
        {
            _deltaTime += Time.realtimeSinceStartup - _lastFrametime;
            if (_deltaTime >= _timePeriod)
            {
                int max = (int)(_deltaTime / _timePeriod);
                for (int i = 0; i < max; i++)
                {
                    OnUpdate.Dispatch();
                    _deltaTime -= _timePeriod;
                }
                _lastFrametime = Time.realtimeSinceStartup - _deltaTime;
            }
            else
            {
                _lastFrametime = Time.realtimeSinceStartup;
            }

        }

        protected override void OnDestroy()
        {
            OnUpdate.RemoveAllListeners();
            OnUpdate = null;
            base.OnDestroy();
        }

        public void ChangeTimePeriod(float timePeriod)
        {
            PauseTime();
            _timePeriod = timePeriod;
            PauseTime();
        }

        public void StartTimer()
        {
            _lastFrametime = Time.realtimeSinceStartup;
            enabled = true;
        }

        public void PauseTime()
        {
            if (enabled)
            {
                //Pause
                _deltaTime += Time.realtimeSinceStartup - _lastFrametime;
            }
            else
            {
                //Start 
                _lastFrametime = Time.realtimeSinceStartup - _deltaTime;
            }
            enabled = !enabled;
        }

        public void StopTimer()
        {
            enabled = false;
        }
    }
}