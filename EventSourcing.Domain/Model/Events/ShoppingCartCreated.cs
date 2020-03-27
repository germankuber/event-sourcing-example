namespace EventSourcing.Domain.Model.Events
{
    //TODO : 04
    public class ShoppingCartCreated : Event
    {
        public string FirstName { get; }
        public int Identifier { get; }
        public string LastName { get; }
        public ShoppingCartCreated(int aggregateId,
                                   string lastName,
                                   string firstName,
                                   int identifier) : base(aggregateId)
        {
            LastName = lastName;
            FirstName = firstName;
            Identifier = identifier;
        }
    }
}