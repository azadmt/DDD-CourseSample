using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class EventAggregator : IEventBus
    {
        public EventAggregator()
        {          
            Subscribers = new List<object>();
        }

        private IList<object> Subscribers { get; }

        public void Subscribe<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent
        {
            Subscribers.Add(eventHandler);
        }



        public void Publish<TEvent>(TEvent eventToPublish) where TEvent : IEvent
        {
            var eligibleSubscribers = GetEligibleSubscribers<TEvent>();
            eligibleSubscribers.ForEach(s =>
            {
                s.Handle(eventToPublish);
            });      
        }


        private List<IEventHandler<TEvent>> GetEligibleSubscribers<TEvent>() where TEvent : IEvent
        {
            return Subscribers.Where(e => e is IEventHandler<TEvent> != null).OfType<IEventHandler<TEvent>>().ToList();
        }

    }


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
