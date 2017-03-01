using System.Collections.Generic;
using OrderSystem.Storage;

namespace OrderSystem.Memberships
{
    public class CustomerMembershipsRepository : IRepository<CustomerMemberships>
    {
        private readonly Dictionary<int, CustomerMemberships> _allDetails = new Dictionary<int, CustomerMemberships>();

        public CustomerMemberships Get(int itemId)
        {
            if (!_allDetails.ContainsKey(itemId)) return null;
            return _allDetails[itemId];
        }

        public void Save(CustomerMemberships item)
        {
            _allDetails[item.CustomerId] = item;
        }
    }
}