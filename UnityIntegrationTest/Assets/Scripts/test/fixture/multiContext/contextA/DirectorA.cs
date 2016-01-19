using strange.extensions.hollywood.impl;
using strange.extensions.hollywood.api;
using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextA
{
    internal class DirectorA : Director<IMessageActor>
    {
        [Inject(SignalEnumA.MySignalA)]
        public Signal<string> mySignalDispatcher { get; set; }

        [Inject(SignalEnumA.FromOutSide)]
        public Signal<string> mySignalFromB { get; set; }

        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
            mySignalFromB.AddListener((string message) => { MyActor.Message = message; });

            MyActor.MessageDispatcher.AddListener((string message) => { mySignalDispatcher.Dispatch(message); });
        }
    }
}