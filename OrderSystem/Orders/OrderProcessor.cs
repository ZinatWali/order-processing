using System;
using OrderSystem.Messaging;
using OrderSystem.Storage;

namespace OrderSystem.Orders
{
    public class OrderProcessor
    {
        private readonly IRepository<PurchaseOrder> _orderRepository;
        private readonly Bus _messageBus;

        public OrderProcessor(IRepository<PurchaseOrder> repository, Bus messageBus)
        {
            _orderRepository = repository;
            _messageBus = messageBus;
        }

        public void Handle(ProcessOrder o)
        {
            Console.WriteLine($"Processing order {o.OrderId}");
            var order = _orderRepository.Get(o.OrderId);
            order.ProcessOrder(_messageBus);
            _orderRepository.Save(order);
        }
    }
}
