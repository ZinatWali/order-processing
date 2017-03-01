using OrderSystem.Customers;
using OrderSystem.Events;
using OrderSystem.Memberships;
using OrderSystem.Messaging;
using OrderSystem.Orders;
using OrderSystem.Shipping;

namespace OrderSystem.Bootstrapper
{
    public class Bootstrap
    {
        public static Bus Boot(PurchaseOrderRepository orderRepo, CustomerDetailsRepository customerDetailsRepository)
        {
            var bus = new Bus();
            var cMembershipsRepo = new CustomerMembershipsRepository();
            var ssRepo = new ShippingSlipRepository();

            var orderProcessor = new OrderProcessor(orderRepo, bus);
            var slipGenerator = new ShippingSlipGenerator(customerDetailsRepository, ssRepo);
            var membershipActivator = new MembershipActivator(cMembershipsRepo);

            bus.Register<ShippingSlipCreated>(slipGenerator.Handle);
            bus.Register<MembershipActivated>(membershipActivator.Handle);
            bus.Register<ProcessOrder>(orderProcessor.Handle);

            return bus;
        }
    }
}