namespace OrderSystem.Events
{
    public class ShippingSlipCreated
    {
        public int OrderId { get; }
        public int CustomerId { get; }
        public string ProductDescription { get; }
        public decimal ProductPrice { get; }

        public ShippingSlipCreated(int orderId, int customerId, string productDescription, decimal productPrice)
        {
            OrderId = orderId;
            CustomerId = customerId;
            ProductDescription = productDescription;
            ProductPrice = productPrice;
        }
    }
}