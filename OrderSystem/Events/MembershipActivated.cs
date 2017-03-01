using System;

namespace OrderSystem.Events
{
    public class MembershipActivated
    {
        public int CustomerId { get; }
        public int OrderId { get; }
        public string Description { get; }
        public decimal Price { get; }
        public DateTime ActivationTime { get; }

        public MembershipActivated(int customerId, int orderId, string description, decimal price, DateTime activationTime)
        {
            CustomerId = customerId;
            OrderId = orderId;
            Description = description;
            Price = price;
            ActivationTime = activationTime;
        }
    }
}