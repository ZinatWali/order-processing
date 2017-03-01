using OrderSystem.Events;
using OrderSystem.Messaging;

namespace OrderSystem.Orders
{
    public class PhysicalProduct : ILineItem
    {
        private readonly string _description;
        private readonly decimal _price;

        public PhysicalProduct(string description, decimal price)
        {
            _description = description;
            _price = price;
        }

        public void ProcessOrderItem(int customerId, int orderId, Bus messageBus)
        {
            messageBus.Publish(new ShippingSlipCreated(orderId, customerId, _description, _price));
        }

        public decimal GetPrice()
        {
            return _price;
        }
    }
}