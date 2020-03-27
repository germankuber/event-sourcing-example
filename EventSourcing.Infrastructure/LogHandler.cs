using System;

namespace EventSourcing.Infrastructure
{
    //TODO : 07
    public class LogHandler
    {
        private readonly IEventStore _eventStore;

        public LogHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
            _eventStore.Notify(x =>
            {
                Console.WriteLine(x);
            });
        }
    }
}