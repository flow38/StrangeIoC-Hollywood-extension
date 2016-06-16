using System;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    [RequireComponent(typeof(global::TouchScript.Gestures.TransformGesture))]
    public class TransformGestureActor : Actor, ITransformGestureActor
    {

        private Signal<TransformInfos> _onStarted;
        private Signal<TransformInfos> _onTransformed;
        private Signal<TransformInfos> _onCompleted;
        private Signal<TransformInfos> _onCancelled;
        private Signal<TransformInfos> _onStateChanged;

        private global::TouchScript.Gestures.TransformGesture _transformGesture;

        #region ITransformGestureActor interface
        public Signal<TransformInfos> OnTransformed
        {
            get { return _onTransformed; }
        }

        public Signal<TransformInfos> OnStarted
        {
            get { return _onStarted; }
        }

        public Signal<TransformInfos> OnCancelled
        {
            get { return _onCancelled; }
        }

        public Signal<TransformInfos> OnCompleted
        {
            get { return _onCompleted; }
        }

        public Signal<TransformInfos> OnStateChanged
        {
            get { return _onStateChanged; }
        }
        #endregion

        #region IGestureListener
        public void StartListenGestures()
        {
            _transformGesture.TransformStarted += onStarted;
            _transformGesture.Transformed += onTransformed;
            _transformGesture.TransformCompleted += onCompleted;
            _transformGesture.Cancelled += onCancelled;
            _transformGesture.StateChanged += onStateChanged;
        }

        public void StopListenGestures()
        {
            _transformGesture.TransformStarted -= onStarted;
            _transformGesture.Transformed -= onTransformed;
            _transformGesture.TransformCompleted -= onCompleted;
            _transformGesture.Cancelled -= onCancelled;
            _transformGesture.StateChanged -= onStateChanged;
        }
        #endregion

        #region MonoBehavior
        protected override void Awake()
        {

            //Create signal for ITransformGestureActor interface
            _onStarted = new Signal<TransformInfos>();
            _onTransformed = new Signal<TransformInfos>();
            _onCompleted = new Signal<TransformInfos>();
            _onCancelled = new Signal<TransformInfos>();
            _onStateChanged = new Signal<TransformInfos>();

            //Get Gesture
            _transformGesture = GetComponent<global::TouchScript.Gestures.TransformGesture>();

            base.Awake();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();

            //Destroy  ITransformGestureActor interface 's signals
            _onStarted.RemoveAllListeners();
            _onStarted = null;

            _onTransformed.RemoveAllListeners();
            _onTransformed = null;

            _onCompleted.RemoveAllListeners();
            _onCompleted = null;

            _onCancelled.RemoveAllListeners();
            _onCancelled = null;

            _onStateChanged.RemoveAllListeners();
            _onStateChanged = null;

            //Destroy gesture reference
            StopListenGestures();
            _transformGesture = null;

        }
        #endregion

        #region private
        protected virtual void onTransformed(object sender, EventArgs e)
        {
            _onTransformed.Dispatch(buildTransformInfos());
        }
        protected virtual void onStarted(object sender, EventArgs e)
        {
            _onTransformed.Dispatch(buildTransformInfos());
        }
        protected virtual void onCompleted(object sender, EventArgs e)
        {
            _onTransformed.Dispatch(buildTransformInfos());
        }
        protected virtual void onCancelled(object sender, EventArgs e)
        {
            _onTransformed.Dispatch(buildTransformInfos());
        }
        protected virtual void onStateChanged(object sender, EventArgs e)
        {
            _onTransformed.Dispatch(buildTransformInfos());
        }

        protected TransformInfos buildTransformInfos()
        {
            TransformInfos infos = new TransformInfos();
            TouchHit hit;
            _transformGesture.GetTargetHitResult(out hit);
            infos.GestureLocation = hit.Point;
            infos.LocalDeltaPosition = _transformGesture.LocalDeltaPosition;

            return infos;
        }

        #endregion

    }
}