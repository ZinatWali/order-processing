using System;
using OrderSystem.Customers;
using OrderSystem.Events;
using OrderSystem.Storage;

namespace OrderSystem.Shipping
{
    public class ShippingSlipGenerator
    {
        private readonly IRepository<CustomerDetails> _customerRepository;
        private readonly IRepository<ShippingSlip> _slipRepository;

        public ShippingSlipGenerator(IRepository<CustomerDetails> customerRepository, IRepository<ShippingSlip> slipRepository)
        {
            _customerRepository = customerRepository;
            _slipRepository = slipRepository;
        }

        public void Handle(ShippingSlipCreated e)
        {
            var customer = _customerRepository.Get(e.CustomerId);
            var slip = new ShippingSlip(customer.Name, customer.Address.FirstLine, customer.Address.SecondLine, e.OrderId, e.ProductPrice); 
            _slipRepository.Save(slip);

            Console.WriteLine($"Shipping slip generated for order {e.OrderId}:");
            Console.WriteLine($"\t{customer.Name}");
            Console.WriteLine($"\t{customer.Address.FirstLine}");
            Console.WriteLine($"\t{customer.Address.SecondLine}");
            Console.WriteLine($"\tTotal Price: {e.ProductPrice}");
        }
    }
}