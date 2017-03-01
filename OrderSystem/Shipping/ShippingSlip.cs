using System;

namespace OrderSystem.Shipping
{
    public class ShippingSlip
    {
        public int SlipId { get; }
        public string CustomerName { get; }
        public string AddressLine1 { get; }
        public string AddressLine2 { get; }
        public int OrderId { get; }
        public decimal Price { get; }

        public ShippingSlip(string customerName, string addressLine1, string addressLine2, int orderId, decimal price) : 
            this(0, customerName, addressLine1, addressLine2, orderId, price)
        {
        }

        public ShippingSlip(int slipId, ShippingSlip s) : this(slipId, s.CustomerName, s.AddressLine1, s.AddressLine2, s.OrderId, s.Price)
        {
        }

        public ShippingSlip(int slipId, string customerName, string addressLine1, string addressLine2, int orderId, decimal price)
        {
            SlipId = slipId;
            CustomerName = customerName;
            AddressLine1 = addressLine1;
            AddressLine2 = addressLine2;
            OrderId = orderId;
            Price = price;
        }
    }
}