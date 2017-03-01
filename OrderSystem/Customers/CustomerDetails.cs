namespace OrderSystem.Customers
{
    public class CustomerDetails
    {
        public Address Address { get; }
        public int CustomerId { get; }
        public string Name { get; }

        public CustomerDetails(int customerId, string name, Address address)
        {
            Address = address;
            CustomerId = customerId;
            Name = name;
        }
    }
}