using System.Collections.Generic;
using EventSourcing.Domain.Model;
using EventSourcing.Domain.Model.Events;

namespace EventSourcing.Infrastructure
{
    //TODO : 08
    public static class Context
    {
        public static List<Event> Events { get; set; } = new List<Event>();
        public static List<ShoppingCart> ShoppingCarts { get; set; } = new List<ShoppingCart>();

    }
}