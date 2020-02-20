using System;

namespace Framework.Core
{
    // Simple Event Handler For inline subscription
    public class ActionHandler<TEvent> : IEventHandler<TEvent> where TEvent : IEvent
    {
        private readonly Action<TEvent> handler;

        public ActionHandler(Action<TEvent> handlerDelegate)
        {
            handler = handlerDelegate;
        }

        public void Handle(TEvent eventToHandle)
        {
            handler(eventToHandle);
        }
    }

}
