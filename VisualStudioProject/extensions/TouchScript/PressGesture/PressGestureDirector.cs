using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl;
using UnityEngine;

namespace strange.extensions.hollywood.extensions.TouchScript.PressGesture
{
    public class PressGestureDirector : Director<IPressGestureActor>
    {

        #region public methods


        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);

            MyActor.OnPressed.AddListener(onPressed);
        }

        public override void OnRemove()
        {
            MyActor.OnPressed.RemoveListener(onPressed);

            base.OnRemove();
        }

        #endregion

        #region private methods
        protected virtual void onPressed(Vector3 pressPosition)
        {
        }
        #endregion
    }
}