using Order2.API.Controllers.Customers.DTO.Address;
using Order2.API.Controllers.Customers.Mapper.Addresses;
using Order2.Domain.Customers.Addresses;
using Xunit;

namespace Order2.API.Tests.Customers
{
    public class AddressMapperTests
    {
        public Address InitiateAddress()
        {
            var address = AddressBuilder.CreateAddress()
                .WithStreetName("Brusselstraat")
                .WithHouseNumber("10")
                .WithZIP("1000")
                .WithCity("Brussel")
                .Build();

            return address;
        }

        private AddressDTO InitiateAddressDTO()
        {
            var addressDTO = new AddressDTO()
                .WithStreetName("Brusselstraat")
                .WithHouseNumber("10")
                .WithCity("Brussel");

           return addressDTO;
        }
        [Fact]
        public void ToDomainTest()
        {
            //given
            var addressMapper = new AddressMapper();
            var addressDTO = InitiateAddressDTO();

            //when
            var address = addressMapper.ToDomain(addressDTO);

            //then
            Assert.Equal(addressDTO.StreetName, address.StreetName);
            Assert.Equal(addressDTO.HouseNumber, address.HouseNumber);
            Assert.Equal(addressDTO.ZIP, address.ZIP);
            Assert.Equal(addressDTO.City, address.City);
        }

        [Fact]
        public void ToDTOTest()
        {
            //given
            var addressMapper = new AddressMapper();
            var address = InitiateAddress();

            //when
            var addressDTO = addressMapper.ToDTO(address);

            //then

            Assert.Equal(addressDTO.StreetName, address.StreetName);
            Assert.Equal(addressDTO.HouseNumber, address.HouseNumber);
            Assert.Equal(addressDTO.ZIP, address.ZIP);
            Assert.Equal(addressDTO.City, address.City);
        }
    }
}
