using System;
using System.Collections.Generic;
using OrderSystem.Storage;

namespace OrderSystem.Customers
{
    public class CustomerDetailsRepository : IRepository<CustomerDetails>
    {
        private readonly Dictionary<int, CustomerDetails> _allDetails = new Dictionary<int, CustomerDetails>();

        public CustomerDetails Get(int itemId)
        {
            if (!_allDetails.ContainsKey(itemId)) return null;
            return _allDetails[itemId];
        }

        public void Save(CustomerDetails item)
        {
            _allDetails[item.CustomerId] = item;
        }
    }
}