namespace EventSourcing.Domain.Model.Events
{
    public class PaymentInformationUpdated : Event
    {
        public string Number { get; }
        public PaymentInformationUpdated(int aggregateId, string number) : base(aggregateId)
        {
            Number = number;
        }
    }
}