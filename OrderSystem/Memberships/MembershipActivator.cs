using System;
using System.Collections.Generic;
using OrderSystem.Events;
using OrderSystem.Storage;

namespace OrderSystem.Memberships
{
    public class MembershipActivator
    {
        private readonly IRepository<CustomerMemberships> _repository;

        public MembershipActivator(IRepository<CustomerMemberships> repository)
        {
            _repository = repository;
        }

        public void Handle(MembershipActivated e)
        {
            var customer = _repository.Get(e.CustomerId) ?? new CustomerMemberships(e.CustomerId, new List<MembershipInfo>());
            var info = new MembershipInfo(e.OrderId, e.Description, e.Price, e.ActivationTime);
            customer.Activate(info);
            _repository.Save(customer);

            Console.WriteLine($"Membership activated for order {e.OrderId}:");
            Console.WriteLine($"\tDescription: {e.Description}");
            Console.WriteLine($"\tPrice: {e.Price}");
        }
    }
}