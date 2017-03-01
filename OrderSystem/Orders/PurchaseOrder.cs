using System.Collections.Generic;
using System.Linq;
using OrderSystem.Messaging;

namespace OrderSystem.Orders
{
    public class PurchaseOrder
    {
        public int OrderId { get; }
        private readonly int _customerId;
        private decimal _totalPrice;
        private readonly List<ILineItem> _lineItems;
        private bool _processed;

        public PurchaseOrder(int customerId, List<ILineItem> lineItems, int orderId, bool processed)
        {
            _customerId = customerId;
            _lineItems = lineItems;
            OrderId = orderId;
            _processed = processed;

            _totalPrice = _lineItems.Sum(x => x.GetPrice());
        }

        public void ProcessOrder(Bus messageBus)
        {
            if(_processed) return;

            foreach (var item in _lineItems)
            {
                item.ProcessOrderItem(_customerId, OrderId, messageBus);
            }

            _processed = true;
        }
    }
}
