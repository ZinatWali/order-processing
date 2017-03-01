using System;

namespace OrderSystem.Memberships
{
    public class MembershipInfo
    {
        public int OrderId { get; }
        public string Description { get; }
        public decimal Price { get; }
        public DateTime ActivationTime { get; }

        public MembershipInfo(int orderId, string description, decimal price, DateTime activationTime)
        {
            OrderId = orderId;
            Description = description;
            Price = price;
            ActivationTime = activationTime;
        }
    }
}