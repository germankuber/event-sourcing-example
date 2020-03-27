using System.Linq;
using EventSourcing.Domain.Model;

namespace EventSourcing.Infrastructure
{
    public class SaveAggregateHandler
    {
        private readonly IEventStore _eventStore;

        public SaveAggregateHandler(IEventStore eventStore)
        {
            _eventStore = eventStore;
            _eventStore.Notify(newEvent =>
            {
                var shoppingCart = Context.ShoppingCarts.FirstOrDefault(x => x.Id == newEvent.AggregateId);
                if (shoppingCart == null)
                {
                    shoppingCart = new ShoppingCart();
                    Context.ShoppingCarts.Add(shoppingCart);
                }


                shoppingCart.Apply(newEvent);
            });
        }
    }
}