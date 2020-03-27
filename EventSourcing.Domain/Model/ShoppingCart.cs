using System;
using EventSourcing.Domain.Model.Events;

namespace EventSourcing.Domain.Model
{
    //TODO : 02
    public class ShoppingCart : Aggregate
    {
        public int Identifier { get; set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public PaymentInformation PaymentInformation { get; set; } = new PaymentInformation();
        public ShoppingCart(int id, string firstName, string lastName, int identifier) : base(id)
        {
            var @event = new ShoppingCartCreated(id, lastName, firstName, identifier);
            Apply(@event);
            Enqueue(@event);
        }

        public ShoppingCart() : base(0)
        {

        }
        public void ChangeName(string firstName, string lastName)
        {
            //TODO: Comportamiento propio y validaciones
            var @event = new ShoppingCartUpdated(Id, lastName, firstName);
            Apply(@event);
            Enqueue(@event);
        }
        public void UpdatePaymentInformation(string number)
        {
            var @event = new PaymentInformationUpdated(Id, number);
            Apply(@event);
            Enqueue(@event);
        }
        private void Apply(ShoppingCartUpdated evt)
        {
            FirstName = evt.FirstName;
            LastName = evt.LastName;
        }
        private void Apply(ShoppingCartCreated evt)
        {
            FirstName = evt.FirstName;
            LastName = evt.LastName;
            Identifier = evt.Identifier;
            Id = evt.AggregateId;

        }
        public void Apply(Event @event)
        {
            if (@event is ShoppingCartCreated created)
                Apply(created);
            if (@event is ShoppingCartUpdated updated)
                Apply(updated);
            if (@event is PaymentInformationUpdated informationUpdated)
                Apply(informationUpdated);
        }

        private void Apply(PaymentInformationUpdated evt)
        {
            PaymentInformation.Number = evt.Number;
        }
    }
}