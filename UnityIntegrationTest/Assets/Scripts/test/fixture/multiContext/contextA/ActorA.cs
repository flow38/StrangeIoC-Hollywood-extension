using strange.extensions.hollywood.impl;
using strange.extensions.signal.impl;
using UnityEngine;

namespace strange.extensions.hollywood.test.fixture.multiContext.contextA
{
    internal class ActorA : Actor, IMessageActor
    {
        [SerializeField] private readonly Signal<string> _messageDisptacher;

        [SerializeField] private string message;

        public ActorA()
        {
            _messageDisptacher = new Signal<string>();
        }

        public string Message
        {
            get { return message; }
            set { message = value; }
        }

        public Signal<string> MessageDispatcher
        {
            get { return _messageDisptacher; }
        }

        public void Update()
        {
            _messageDisptacher.Dispatch("message from A context!!");
        }
    }
}