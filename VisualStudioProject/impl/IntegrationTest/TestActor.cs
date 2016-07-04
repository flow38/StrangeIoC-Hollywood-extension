using strange.extensions.hollywood.api.IntegrationTest;
using strange.extensions.injector.api;

namespace strange.extensions.hollywood.impl.IntegrationTest
{
    public class TestActor : Actor, ITestActor
    {
        public virtual void DoTest(IInjectionBinder injectionBinder)
        {
            throw new System.NotImplementedException();
        }
    }
}