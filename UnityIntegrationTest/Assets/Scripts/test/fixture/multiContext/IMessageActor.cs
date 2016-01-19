using strange.extensions.signal.impl;

namespace strange.extensions.hollywood.test.fixture.multiContext
{
    public interface IMessageActor
    {
        string Message { get; set; }

        Signal<string> MessageDispatcher { get; }
    }
}