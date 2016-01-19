using strange.extensions.hollywood.impl;
using strange.extensions.context.api;
using strange.extensions.hollywood.test.fixture.multiContext.contextA;
using strange.extensions.hollywood.test.fixture.multiContext.contextB;
using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.test.fixture.multiContext
{
    public class RootContext : HollywoodMVCSContext
    {
        public RootContext(MonoBehaviour view) : base(view)
        {
        }

        public RootContext(MonoBehaviour view, ContextStartupFlags flags) : base(view, flags)
        {
        }

        protected override void mapBindings()
        {
            base.mapBindings();

            //Injection binding.
            //Map a mock model and a mock service, both as Singletons
            //Example
            //injectionBinder.Bind<IExampleModel>().To<ExampleModel>().ToSingleton();
            //injectionBinder.Bind<IExampleService>().To<ExampleService>().ToSingleton();
            var signalA = new Signal<string>();
            var signalB = new Signal<string>();
            injectionBinder.Bind<Signal<string>>().ToName(SignalEnumA.FromOutSide).ToValue(signalB).CrossContext();
            injectionBinder.Bind<Signal<string>>().ToName(SignalEnumA.MySignalA).ToValue(signalA).CrossContext();

            injectionBinder.Bind<Signal<string>>().ToName(SignalEnumB.FromOutSide).ToValue(signalA).CrossContext();
            injectionBinder.Bind<Signal<string>>().ToName(SignalEnumB.MySignalB).ToValue(signalB).CrossContext();
        }
    }
}