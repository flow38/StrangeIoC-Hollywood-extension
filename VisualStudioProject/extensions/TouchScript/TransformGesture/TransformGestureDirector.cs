using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    public class TransformGestureDirector : Director<ITransformGestureActor>
    {

        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
            MyActor.OnTransformGesture.AddListener(onTransformGesture);
        }

        public override void OnRemove()
        {
            MyActor.OnTransformGesture.RemoveListener(onTransformGesture);

            base.OnRemove();
        }

        /// <summary>
        /// Implement onTransformGesture in your subclass !
        /// </summary>
        /// <param name="infos"></param>
        protected virtual void onTransformGesture(TransformGestureInfos infos)
        {

        }
    }
}