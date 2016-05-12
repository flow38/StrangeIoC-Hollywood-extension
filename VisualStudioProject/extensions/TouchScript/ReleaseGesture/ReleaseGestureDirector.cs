using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.ReleaseGesture
{
    public class ReleaseGestureDirector : Director<IReleaseGestureActor>
    {

        #region public methods


        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);

            MyActor.OnReleased.AddListener(onReleased);
        }

        public override void OnRemove()
        {
            MyActor.OnReleased.RemoveListener(onReleased);

            base.OnRemove();
        }

        #endregion

        #region private methods
        protected virtual void onReleased(Vector3 pressPosition)
        {
        }
        #endregion
    }
}