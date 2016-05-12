using System;
using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using TouchScript.Hit;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.PressGesture
{
    [RequireComponent(typeof(global::TouchScript.Gestures.PressGesture))]
    public class PressGestureActor : Actor, IPressGestureActor
    {
        #region private properties
        private global::TouchScript.Gestures.PressGesture _pressGesture;

        /// <summary>
        /// Player pressed & released event dispatcher
        /// bool is true on pressed event and false on released.
        /// Vector3 is GameObject transform position on which gesture is triggered
        /// </summary>
        private Signal<bool, Vector3> _onPressed;
        #endregion

        #region public properties  & getter/setter
        /// <summary>
        /// Player pressed & released event dispatcher
        /// bool is true on pressed event and false on released.
        /// Vector3 is GameObject transform position on which gesture is triggered
        /// </summary>
        public Signal<bool, Vector3> OnPressed
        {
            get { return _onPressed; }
        }
        #endregion

        #region IGestureListener
        public void StartListenGestures()
        {
            //Pressed
            _pressGesture.Pressed += onPressedHandler;
        }


        public void StopListenGestures()
        {
            //Pressed
            _pressGesture.Pressed -= onPressedHandler;
        }

        #endregion


        #region MonoBehavior
        protected override void Awake()
        {
            _onPressed = new Signal<bool, Vector3>();
            _pressGesture = GetComponent<global::TouchScript.Gestures.PressGesture>();
            base.Awake();
        }


        protected override void OnDestroy()
        {
            base.OnDestroy();
            _onPressed.RemoveAllListeners();
            _onPressed = null;
            StopListenGestures();
            _pressGesture = null;
        }
        #endregion

        #region private methods

        protected virtual void onPressedHandler(object sender, EventArgs e)
        {
            TouchHit hit;
            _pressGesture.GetTargetHitResult(out hit);
            _onPressed.Dispatch(true, hit.Point);
        }

        #endregion
    }
}