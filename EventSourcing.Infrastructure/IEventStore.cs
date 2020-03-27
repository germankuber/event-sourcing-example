using System;
using System.Collections.Generic;
using EventSourcing.Domain.Model.Events;

namespace EventSourcing.Infrastructure
{

    public interface IEventStore
    {
        void Append(List<Event> @event);
        void Notify(Action<Event> callBackEvents);
        IEnumerable<Event> Read();
        void Save();
    }
}
