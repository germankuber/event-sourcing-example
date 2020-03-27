namespace EventSourcing.Infrastructure
{
    public class SaveEventsHandler
    {
        private readonly IEventStore _eventStore;

        public SaveEventsHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
            _eventStore.Notify(x =>
            {
                Context.Events.Add(x);
            });
        }
    }
}