using System;

namespace EventSourcing.Domain.Model.Events
{
    //TODO: 03
    public abstract class Event
    {
        public DateTime TimeStamp { get; private set; }
        public int AggregateId { get; set; }
        public Guid EventId { get; set; } = Guid.NewGuid();

        protected Event(int aggregateId)
        {
            AggregateId = aggregateId;
            TimeStamp = DateTime.Now;
        }
    }
}