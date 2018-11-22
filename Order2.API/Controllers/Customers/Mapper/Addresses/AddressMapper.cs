using Order2.API.Controllers.Customers.DTO.Address;
using Order2.Domain.Customers.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers.Mapper.Addresses
{
    public class AddressMapper : IAddressMapper
    {
        public Address ToDomain(AddressDTO addressDTO)
        {
            return AddressBuilder.CreateAddress()
                .WithStreetName(addressDTO.StreetName)
                .WithHouseNumber(addressDTO.HouseNumber)
                .WithZIP(addressDTO.ZIP)
                .WithCity(addressDTO.City)
                .Build();
        }

        public AddressDTO ToDTO(Address address)
        {
            return new AddressDTO()
                .WithStreetName(address.StreetName)
                .WithHouseNumber(address.HouseNumber)
                .WithZIP(address.ZIP)
                .WithCity(address.City);
        }
    }
}
