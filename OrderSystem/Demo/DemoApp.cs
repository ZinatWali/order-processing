using System.Collections.Generic;
using OrderSystem.Bootstrapper;
using OrderSystem.Customers;
using OrderSystem.Orders;

namespace OrderSystem.Demo
{
    public static class DemoApp
    {
        public static void Main()
        {
            var customerDetails = new CustomerDetailsRepository();
            customerDetails.Save(new CustomerDetails(1, "John Doe", new Address("123, Paradise Lost", "Homer Street")));
            customerDetails.Save(new CustomerDetails(2, "Jane Doe", new Address("123, Odyssey House", "Homer Stret")));
            customerDetails.Save(new CustomerDetails(3, "Joe Black", new Address("123, Heven Lodge", "Mitch Street")));
            customerDetails.Save(new CustomerDetails(4, "Raymond Red", new Address("123, Obelix Court", "Renaissance Walk")));

            var orderRepository = new PurchaseOrderRepository();
            orderRepository.Save(new PurchaseOrder(1, new List<ILineItem>{ new PhysicalProduct("Man In Black", 5.0m), new PhysicalProduct("Fifth Season", 6.0m) }, 1, false));
            orderRepository.Save(new PurchaseOrder(4, new List<ILineItem>{ new PhysicalProduct("Grey's Anatomy", 5.0m), new Membership("Video Club", 6.0m) }, 2, false));
            orderRepository.Save(new PurchaseOrder(2, new List<ILineItem>{ new Membership("Book Club", 5.0m), new PhysicalProduct("Fifth Season", 6.0m) }, 3, false));
            orderRepository.Save(new PurchaseOrder(3, new List<ILineItem>{ new PhysicalProduct("The Theory of Everything", 5.0m), new PhysicalProduct("Space Odyssey", 6.0m) }, 4, false));

            var bus = Bootstrap.Boot(orderRepository, customerDetails);

            for (int i = 0; i < 4; i++)
            {
                bus.Execute(new ProcessOrder(i+1));
            }
        }
    }
}