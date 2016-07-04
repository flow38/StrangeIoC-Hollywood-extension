using strange.extensions.injector.api;

namespace strange.extensions.hollywood.api.IntegrationTest
{
    public interface ITestActor : IActor
    {
        /// <summary>
        /// Execute integration test.
        /// Call by actor's director at context startup (aka contextView Start() method invokation)
        /// </summary>
        /// <param name="injectionBinder">An injection binder instance to get Strange power in yours ActorTest instances</param>
        void DoTest(IInjectionBinder injectionBinder);
    }
}