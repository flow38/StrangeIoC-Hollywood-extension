using strange.extensions.hollywood.api.IntegrationTest;
using strange.extensions.injector.api;

namespace strange.extensions.hollywood.impl.IntegrationTest
{
    public class TestDirector : Director<ITestActor>
    {
        /// <summary>
        /// TestActor's parent context IInjection Binder instance
        /// </summary>
        private IInjectionBinder _contextInjectionBinder;

        private readonly LaunchAppIsDoneSignal _launchAppIsDone;


        [Construct]
        public TestDirector(IInjectionBinder injectionBinder, LaunchAppIsDoneSignal launchAppIsDone) : base()
        {
            _contextInjectionBinder = injectionBinder;
            _launchAppIsDone = launchAppIsDone;
            _launchAppIsDone.AddOnce(doTest);
        }

        private void doTest()
        {
            MyActor.DoTest(_contextInjectionBinder);
        }
    }
}