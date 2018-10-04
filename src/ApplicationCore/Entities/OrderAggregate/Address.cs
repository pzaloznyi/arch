namespace OnlineShop.ApplicationCore.Entities.OrderAggregate
{
    public class Address
    {
        public string Street { get; private set; }

        public string City { get; private set; }

        public string Country { get; private set; }

        public string Phone { get; private set; }

        private Address() { }

        public Address(string street, string city, string country, string phone)
        {
            Street = street;
            City = city;
            Country = country;
            Phone = phone;
        }
    }
}
