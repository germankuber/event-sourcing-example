using System;
using System.Collections.Generic;
using System.Linq;
using EventSourcing.Domain.Model.Events;

namespace EventSourcing.Domain
{
    //TODO : 01
    public abstract class Aggregate
    {
        public int Id { get; protected set; }

        private readonly List<Event> _events = new List<Event>();
        
        protected Aggregate(int id)
        {
            Id = id;
        }

        protected void Enqueue(Event @event) => _events.Add(@event);

        public IEnumerable<Event> DequeueUncommittedEvents()
        {
            var dequeuedEvents = _events.ToList();
            _events.Clear();
            return dequeuedEvents;
        }
    }
}