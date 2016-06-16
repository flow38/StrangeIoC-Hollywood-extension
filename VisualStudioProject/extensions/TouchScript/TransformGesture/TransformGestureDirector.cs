using strange.extensions.hollywood.api;
using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.extensions.TouchScript.TransformGesture
{
    public class TransformGestureDirector : Director<ITransformGestureActor>
    {

        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
            //Example : 
            //MyActor.OnStarted.AddListener(yourCustomMethod);
        }

        public override void OnRemove()
        {
            //Example : 
            //MyActor.OnStarted.RemoveListener(yourCustomMethod);

            base.OnRemove();
        }

    }
}