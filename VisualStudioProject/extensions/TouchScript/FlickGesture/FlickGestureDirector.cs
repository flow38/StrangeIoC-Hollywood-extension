using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.FlickGesture
{
    public class FlickGestureDirector : Director<IFlickGestureActor>
    {



        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
            MyActor.OnFlickGesture.AddListener(onFlickGesture);
        }

        public override void OnRemove()
        {
            MyActor.OnFlickGesture.RemoveListener(onFlickGesture);

            base.OnRemove();
        }

        /// <summary>
        /// Implement onFlickGesture in your subclass !
        /// </summary>
        /// <param name="infos"></param>
        protected virtual void onFlickGesture(FlickGestureInfo infos)
        {

        }
    }
}