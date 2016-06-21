using System;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.TapGesture
{

    [RequireComponent(typeof(global::TouchScript.Gestures.TapGesture))]
    public class TapGestureActor : Actor, ITapGestureActor
    {
        private global::TouchScript.Gestures.TapGesture _tapGesture;

        private Signal<Vector3> _onTapped;

        public Signal<Vector3> OnTapped
        {
            get { return _onTapped; }
            set { _onTapped = value; }
        }

        #region IGestureListener
        public void StartListenGestures()
        {
            _tapGesture.Tapped += onTapped;
        }

        public void StopListenGestures()
        {
            _tapGesture.Tapped -= onTapped;
        }
        #endregion

        #region MonoBehavior
        protected override void Awake()
        {
            //Create signal for ITapGestureActor interface
            _onTapped = new Signal<Vector3>();

            //Get Gesture
            _tapGesture = GetComponent<global::TouchScript.Gestures.TapGesture>();

            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //Destroy  ITapGestureActor interface 's signals
            _onTapped.RemoveAllListeners();
            _onTapped = null;


            //Destroy gesture reference
            StopListenGestures();
            _tapGesture = null;

        }
        #endregion


        #region private

        private void onTapped(object sender, EventArgs e)
        {
            TouchHit hit;
            _tapGesture.GetTargetHitResult(out hit);
            OnTapped.Dispatch(hit.Point);
        }
        #endregion
    }
}