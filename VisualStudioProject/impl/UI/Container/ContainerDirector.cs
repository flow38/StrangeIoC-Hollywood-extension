using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.impl.UI.Container
{
    public class ContainerDirector : Director<IContainerActor>
    {
        /// <summary>
        ///     Fires after all injections satisifed.
        ///     Override and place your initialization code here
        ///     ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        /// </summary>
        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
        }

        /// <summary>
        ///     Fires directly after creation and before injection
        /// </summary>
        public virtual void PreRegister()
        {
            base.PreRegister();
        }

        /// <summary>
        ///     Fires on removal of view.
        ///     Override and place your cleanup code here
        ///     ALWAYS CALL Base.OnRegister IN YOUR OVERRIDE IMPLEMENTATION !!!
        /// </summary>
        public virtual void OnRemove()
        {
            base.OnRemove();
        }
    }
}