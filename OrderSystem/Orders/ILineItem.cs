using OrderSystem.Messaging;

namespace OrderSystem.Orders
{
    public interface ILineItem
    {
        void ProcessOrderItem(int customerId, int orderId, Bus messageBus);
        decimal GetPrice();
    }
}