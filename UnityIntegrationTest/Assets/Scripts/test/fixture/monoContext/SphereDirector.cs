using strange.extensions.hollywood.impl;
using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.test.fixture.monoContext
{
    internal class SphereDirector : Director<ISphereActor>
    {
        public ISphereActor SphereActor { get; set; }

        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);

            MyActor.MyDirectoryCalledMe = true;
        }
    }
}