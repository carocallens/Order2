namespace Order2.API.Controllers.Customers.DTO.Address
{
    public class AddressDTO
    {
        public string StreetName { get; set; }
        public string HouseNumber { get; set; }
        public string ZIP { get; set; }
        public string City { get; set; }

        public AddressDTO WithStreetName(string streetName)
        {
            StreetName = streetName;
            return this;
        }

        public AddressDTO WithHouseNumber(string houseNumber)
        {
            HouseNumber = houseNumber;
            return this;
        }

        public AddressDTO WithZIP(string zip)
        {
            ZIP = zip;
            return this;
        }

        public AddressDTO WithCity(string city)
        {
            City = city;
            return this;
        }
    }
}
