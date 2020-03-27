namespace EventSourcing.Domain.Model.Events
{
    public class ShoppingCartUpdated : Event
    {
        public string FirstName { get; }
        public string LastName { get; }
        public ShoppingCartUpdated(int aggregateId, string lastName, string firstName) : base(aggregateId)
        {
            LastName = lastName;
            FirstName = firstName;
        }
    }
}