using System;
using strange.extensions.hollywood.extensions.TouchScript.FlickGesture;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    [RequireComponent(typeof(global::TouchScript.Gestures.TransformGesture))]
    public class TransformGestureActor : Actor, ITransformGestureActor
    {
        private Signal<TransformGestureInfos> _onTransformGesture;
        private global::TouchScript.Gestures.TransformGesture _transformGesture;
        private TransformGestureInfos _transformGestureInfos;

        public Signal<TransformGestureInfos> OnTransformGesture
        {
            get { return _onTransformGesture; }
        }

        #region IGestureListener
        public void StartListenGestures()
        {
            _transformGesture.Transformed += OnTransformGestureStarted;
        }

        public void StopListenGestures()
        {
            _transformGesture.Transformed -= OnTransformGestureStarted;
        }
        #endregion

        #region MonoBehavior
        protected override void Awake()
        {

            //Create signal for ITransformGestureActor interface
            _onTransformGesture = new Signal<TransformGestureInfos>();

            //Get Gesture
            _transformGesture = GetComponent<global::TouchScript.Gestures.TransformGesture>();

            //Create gesture VO
            _transformGestureInfos = new TransformGestureInfos();


            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //Destroy  ITransformGestureActor interface 's signal
            _onTransformGesture.RemoveAllListeners();
            _onTransformGesture = null;

            //Destroy gesture reference
            StopListenGestures();
            _transformGesture = null;

            //Destroy gesture VO
            _transformGestureInfos = null;
        }
        #endregion

        #region private
        protected virtual void OnTransformGestureStarted(object sender, EventArgs e)
        {
            TouchHit hit;
            _transformGesture.GetTargetHitResult(out hit);
            _transformGestureInfos.GestureLocation = hit.Point;
            _transformGestureInfos.LocalDeltaPosition = _transformGesture.LocalDeltaPosition;
            //_transformGesture.Cancel(); ?
            _onTransformGesture.Dispatch(_transformGestureInfos);
        }

        #endregion

    }
}