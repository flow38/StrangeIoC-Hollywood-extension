using strange.extensions.hollywood.impl;
using strange.extensions.hollywood.api;
using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextB
{
    internal class DirectorB : Director<IMessageActor>
    {
        [Inject(SignalEnumB.MySignalB)]
        public Signal<string> mySignalDispatcher { get; set; }

        [Inject(SignalEnumB.FromOutSide)]
        public Signal<string> mySignalFromA { get; set; }

        public override void OnRegister(IActor actor)
        {
            base.OnRegister(actor);
            mySignalFromA.AddListener((string message) => { MyActor.Message = message; });

            MyActor.MessageDispatcher.AddListener((string message) => { mySignalDispatcher.Dispatch(message); });
        }
    }
}