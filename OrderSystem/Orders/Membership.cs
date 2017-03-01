using System;
using OrderSystem.Events;
using OrderSystem.Messaging;

namespace OrderSystem.Orders
{
    public class Membership : ILineItem
    {
        private readonly string _description;
        private readonly decimal _price;

        public Membership(string description, decimal price)
        {
            _description = description;
            _price = price;
        }

        public void ProcessOrderItem(int customerId, int orderId, Bus messageBus)
        {
            messageBus.Publish(new MembershipActivated(customerId, orderId, _description, _price, DateTime.Now));
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}
