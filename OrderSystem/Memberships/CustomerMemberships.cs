using System.Collections.Generic;

namespace OrderSystem.Memberships
{
    public class CustomerMemberships
    {
        public int CustomerId { get; }
        public List<MembershipInfo> Memberships { get; }

        public CustomerMemberships(int customerId, List<MembershipInfo> memberships)
        {
            CustomerId = customerId;
            Memberships = memberships;
        }
        
        public void Activate(MembershipInfo m)
        {
            Memberships.Add(m);
        }
    }
}