using strange.extensions.hollywood.impl;
using strange.extensions.context.api;
using UnityEngine;

namespace strange.extensions.hollywood.test.fixture.monoContext
{
    public class MyHollywoodContext : HollywoodMVCSContext
    {
        public MyHollywoodContext(MonoBehaviour view) : base(view)
        {
        }

        public MyHollywoodContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            #region Actor to Director Binding

            //Actor/Director binding
            mediationBinder.Bind<SphereActor>().To<SphereDirector>();

            #endregion

            // mediationBinder.Bind<SphereActor>().To<SphereDirector>();
        }
    }
}