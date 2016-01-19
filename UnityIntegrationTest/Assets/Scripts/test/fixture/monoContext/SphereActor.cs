using strange.extensions.hollywood.impl;

namespace strange.extensions.hollywood.test.fixture.monoContext
{
    internal class SphereActor : Actor, ISphereActor
    {
        public SphereActor()
        {
            MyDirectoryCalledMe = false;
        }

        public bool MyDirectoryCalledMe { get; set; }

        public void HelloFromDirector()
        {
            MyDirectoryCalledMe = true;
        }
    }
}