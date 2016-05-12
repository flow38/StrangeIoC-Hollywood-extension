using System;
using strange.extensions.hollywood.extensions.TouchScript.PressGesture;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.ReleaseGesture
{
    [RequireComponent(typeof(global::TouchScript.Gestures.ReleaseGesture))]
    public class ReleaseGestureActor : Actor, IReleaseGestureActor
    {
        #region private properties
        private global::TouchScript.Gestures.ReleaseGesture _releaseGesture;

        /// <summary>
        /// Player pressed & released event dispatcher
        /// bool is true on pressed event and false on released.
        /// Vector3 is GameObject transform position on which gesture is triggered
        /// </summary>
        private Signal<Vector3> _onRelease;
        #endregion

        #region public properties  & getter/setter
        /// <summary>
        /// Player pressed & released event dispatcher
        /// bool is true on pressed event and false on released.
        /// Vector3 is GameObject transform position on which gesture is triggered
        /// </summary>
        public Signal<Vector3> OnReleased
        {
            get { return _onRelease; }
        }
        #endregion

        #region IGestureListener
        public void StartListenGestures()
        {
            //Pressed
            _releaseGesture.Released += onReleaseHandler;
        }


        public void StopListenGestures()
        {
            //Pressed
            _releaseGesture.Released -= onReleaseHandler;
        }

        #endregion


        #region MonoBehavior
        protected override void Awake()
        {
            _onRelease = new Signal<Vector3>();
            _releaseGesture = GetComponent<global::TouchScript.Gestures.ReleaseGesture>();
            base.Awake();
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            _onRelease.RemoveAllListeners();
            _onRelease = null;
            StopListenGestures();
            _releaseGesture = null;
        }
        #endregion

        #region private methods

        protected virtual void onReleaseHandler(object sender, EventArgs e)
        {
            TouchHit hit;
            _releaseGesture.GetTargetHitResult(out hit);
            _onRelease.Dispatch(hit.Point);
        }

        #endregion
    }
}