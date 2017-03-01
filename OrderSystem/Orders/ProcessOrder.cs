namespace OrderSystem.Orders
{
    public class ProcessOrder
    {
        public int OrderId { get; }

        public ProcessOrder(int orderId)
        {
            this.OrderId = orderId;
        }
    }
}