using System;
using System.Collections.Generic;
using EventSourcing.Domain.Model.Events;

namespace EventSourcing.Infrastructure
{
    //TODO : 05
    public class EventStore : IEventStore
    {
        private List<Event> _events = new List<Event>();
        private List<Action<Event>> _callBacks = new List<Action<Event>>();
        public void Append(List<Event> @event)
        {
            _events.AddRange(@event);
        }

        public void Notify(Action<Event> callBackEvents) =>
            _callBacks.Add(callBackEvents);

        public IEnumerable<Event> Read() => _events;

        public void Save()
        {
            foreach (var callBack in _callBacks)
                foreach (var @event in _events)
                    callBack(@event);
            _events.Clear();
        }
    }
}