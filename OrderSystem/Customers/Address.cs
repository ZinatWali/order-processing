namespace OrderSystem.Customers
{
    public class Address
    {
        public string FirstLine { get; }
        public string SecondLine { get; }

        public Address(string firstLine, string secondLine)
        {
            FirstLine = firstLine;
            SecondLine = secondLine;
        }    
    }
}