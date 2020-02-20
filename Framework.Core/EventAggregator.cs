using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Core
{
    public class EventAggregator : IEventBus
    {
        Queue<IExternalMessage> externalMessages = new Queue<IExternalMessage>();
        IEnterpriseServiceBus enterpriseServiceBus;

        public EventAggregator(IEnterpriseServiceBus enterpriseServiceBus)
        {
            Subscribers = new List<object>();
            this.enterpriseServiceBus = enterpriseServiceBus;
            
            Subscribe(new ActionHandler<TransactionCommitedEvent>(a => {
                PublishExternalMessages();
            }));
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

            if (eventToPublish is IExternalMessage)
            {
                externalMessages.Enqueue((IExternalMessage)eventToPublish);
            }
        }

        private void PublishExternalMessages()
        {
            while (externalMessages.Any())
            {
                //TODO : Handle Exception 
                var message = externalMessages.Dequeue();
                enterpriseServiceBus.Publish(message);
            }
        }

        private List<IEventHandler<TEvent>> GetEligibleSubscribers<TEvent>() where TEvent : IEvent
        {
            var eligibleSubscribers = new List<IEventHandler<TEvent>>();
            var handlers = ServiceLocator.Current.ResolveAll<IEventHandler<TEvent>>().ToList();
            var inlineHandlers = Subscribers.Where(e => e is IEventHandler<TEvent> != null).OfType<IEventHandler<TEvent>>().ToList();
            eligibleSubscribers.AddRange(handlers);
            eligibleSubscribers.AddRange(inlineHandlers);
            return eligibleSubscribers;
        }
    }
}
