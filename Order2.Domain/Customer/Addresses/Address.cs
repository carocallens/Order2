using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Domain.Customers.Addresses
{
    public class Address
    {
        public string StreetName { get; private set; }
        public string HouseNumber { get; private set; }
        public string ZIP { get; private set; }
        public string City { get; private set; }

        private Address() { }

        public Address(AddressBuilder addressBuilder)
        {
            StreetName = addressBuilder.StreetName;
            HouseNumber = addressBuilder.HouseNumber;
            ZIP = addressBuilder.ZIP;
            City = addressBuilder.City;
        }
    }

    public class AddressBuilder
    {
        public string StreetName { get; private set; }
        public string HouseNumber { get; private set; }
        public string ZIP { get; private set; }
        public string City { get; private set; }

        private AddressBuilder() { }

        public static AddressBuilder CreateAddress()
        {
            return new AddressBuilder();
        }

        public Address Build()
        {
            return new Address(this);
        }

        public AddressBuilder WithStreetName(string streetName)
        {
            StreetName = streetName;
            return this;
        }

        public AddressBuilder WithHouseNumber(string houseNumber)
        {
            HouseNumber = houseNumber;
            return this;
        }

        public AddressBuilder WithZIP(string zip)
        {
            ZIP = zip;
            return this;
        }

        public AddressBuilder WithCity(string city)
        {
            City = city;
            return this;
        }

    }
}
