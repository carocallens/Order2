using Order2.API.Controllers.Customers.DTO.Address;
using Order2.Domain.Customers.Addresses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers.Mapper.Addresses
{
    public interface IAddressMapper
    {
        Address ToDomain(AddressDTO addressDTO);
        AddressDTO ToDTO(Address address);
    }
}
