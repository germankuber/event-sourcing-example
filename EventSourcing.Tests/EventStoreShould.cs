using System.Linq;
using EventSourcing.Domain.Model;
using EventSourcing.Infrastructure;
using Xunit;

namespace EventSourcing.Tests
{
    public class EventStoreShould
    {
        [Fact]
        public void Call_Handlers()
        {
            var eventStore = new EventStore();
            new LogHandler(eventStore);
            new SaveEventsHandler(eventStore);

            var shoppingCart = new ShoppingCart(4, "FirstName", "LastName", 12345);
            shoppingCart.ChangeName("SecondName", "SecondName");

            Save(shoppingCart, eventStore);
        }

        [Fact]
        public void Call_SaveAggregateHandler()
        {
            var eventStore = new EventStore();
            new LogHandler(eventStore);
            new SaveEventsHandler(eventStore);
            new SaveAggregateHandler(eventStore);

            var shoppingCart = new ShoppingCart(4, "FirstName", "LastName", 12345);
            shoppingCart.ChangeName("SecondName", "SecondName");

            Save(shoppingCart, eventStore);


            shoppingCart.UpdatePaymentInformation("1111");

            Save(shoppingCart, eventStore);

            var allEvents = Context.Events.ToList();    
        }



        static void Save(ShoppingCart shoppingCart, EventStore eventStore)
        {
            var eventsToStore = shoppingCart.DequeueUncommittedEvents().ToList();
            eventStore.Append(eventsToStore);
            eventStore.Save();
        }
    }
}
