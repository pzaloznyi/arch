using OnlineShop.ApplicationCore.Entities.OrderAggregate;

namespace OnlineShop.UnitTests.Builders
{
    public class AddressBuilder
    {
        private Address _address;
        public string TestStreet => "123";
        public string TestCity => "Kyiv";
        public string TestCountry => "Ukraine";
        public string Phone => "0123456789";

        public AddressBuilder()
        {
            _address = WithDefaultValues();
        }
        public Address Build()
        {
            return _address;
        }
        public Address WithDefaultValues()
        {
            _address = new Address(TestStreet, TestCity, TestCountry, Phone);
            return _address;
        }
    }
}
