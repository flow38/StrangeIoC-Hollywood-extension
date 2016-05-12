using System;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.FlickGesture
{

    [RequireComponent(typeof(global::TouchScript.Gestures.FlickGesture))]
    public class FlickGestureActor : Actor, IFlickGestureActor
    {
        protected global::TouchScript.Gestures.FlickGesture _flickGesture;
        protected FlickGestureInfo gestureInfos;
        protected Signal<FlickGestureInfo> _onFlickGesture;


        public Signal<FlickGestureInfo> OnFlickGesture
        {
            get { return _onFlickGesture; }
        }

        #region IGestureListener
        public void StartListenGestures()
        {
            //Flick
            _flickGesture.Flicked += onFlick;
        }


        public void StopListenGestures()
        {
            _flickGesture.Flicked -= onFlick;
        }

        #endregion

        #region MonoBehavior
        protected override void Awake()
        {

            //Create signal for ITransformGestureActor interface
            _onFlickGesture = new Signal<FlickGestureInfo>();

            //Get Gesture
            _flickGesture = GetComponent<global::TouchScript.Gestures.FlickGesture>();

            //Create gesture VO
            gestureInfos = new FlickGestureInfo();

            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //Destroy  ITransformGestureActor interface 's signal
            _onFlickGesture.RemoveAllListeners();
            _onFlickGesture = null;

            //Destroy gesture reference
            StopListenGestures();
            _flickGesture = null;

            //Destroy gesture VO
            gestureInfos = null;
        }
        #endregion

        #region protected
        protected virtual void onFlick(object sender, EventArgs e)
        {
            TouchHit hit;
            _flickGesture.GetTargetHitResult(out hit);
            gestureInfos.Hit = hit;
            gestureInfos.FlickVector = _flickGesture.ScreenFlickVector;
            _onFlickGesture.Dispatch(gestureInfos);
        }

        #endregion
    }
}