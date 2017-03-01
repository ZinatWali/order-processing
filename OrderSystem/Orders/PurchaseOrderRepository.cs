using System.Collections.Generic;
using OrderSystem.Storage;

namespace OrderSystem.Orders
{
    public class PurchaseOrderRepository : IRepository<PurchaseOrder>
    {
        private readonly Dictionary<int, PurchaseOrder> _allDetails = new Dictionary<int, PurchaseOrder>();

        public PurchaseOrder Get(int itemId)
        {
            if (!_allDetails.ContainsKey(itemId)) return null;
            return _allDetails[itemId];
        }

        public void Save(PurchaseOrder item)
        {
            _allDetails[item.OrderId] = item;
        }
    }
}