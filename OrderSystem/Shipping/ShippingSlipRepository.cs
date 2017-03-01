using System.Collections.Generic;
using System.Linq;
using OrderSystem.Storage;

namespace OrderSystem.Shipping
{
    public class ShippingSlipRepository : IRepository<ShippingSlip>
    {
        private readonly Dictionary<int, ShippingSlip> _allDetails = new Dictionary<int, ShippingSlip>();

        private readonly object _lockObject = new object();

        public ShippingSlip Get(int itemId)
        {
            lock (_lockObject)
            {
                if (!_allDetails.ContainsKey(itemId)) return null;
                return _allDetails[itemId];
            }
        }

        public void Save(ShippingSlip item)
        {
            lock (_lockObject)
            {
                if (item.SlipId == 0) item = new ShippingSlip(_allDetails.Any() ? _allDetails.Keys.Max() + 1 : 1, item);
                _allDetails[item.SlipId] = item;
            }
        }
    }
}