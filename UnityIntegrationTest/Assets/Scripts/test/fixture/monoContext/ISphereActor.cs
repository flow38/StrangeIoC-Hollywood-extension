using strange.extensions.hollywood.api;

namespace strange.extensions.hollywood.test.fixture.monoContext
{
    public interface ISphereActor : IActor
    {
        bool MyDirectoryCalledMe { get; set; }
        void HelloFromDirector();
    }
}