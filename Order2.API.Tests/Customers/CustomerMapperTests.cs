using Order2.API.Controllers.Customers.DTO;
using Order2.API.Controllers.Customers.DTO.Address;
using Order2.API.Controllers.Customers.Mapper;
using Order2.API.Controllers.Customers.Mapper.Addresses;
using Order2.Domain.Customers;
using Order2.Domain.Customers.Addresses;
using Xunit;

namespace Order2.API.Tests.Customers
{
    public class CustomerMapperTests
    {
        public Customer InitiateCustomer()
        {
            var address = AddressBuilder.CreateAddress()
                .WithStreetName("Brusselstraat")
                .WithHouseNumber("10")
                .WithZIP("1000")
                .WithCity("Brussel")
                .Build();

            var customer = CustomerBuilder.CreateCustomer()
                .WithFirstName("Jan")
                .WithLastName("Peeters")
                .WithEmail("jan.peeters@email.com")
                .WithPhoneNumber("0470000000")
                .WithAddress(address)
                .Build();

            return customer;
        }

        private CustomerDTO_Request InitiateCustomerDTO()
        {
            var addressDTO = new AddressDTO()
                .WithStreetName("Brusselstraat")
                .WithHouseNumber("10")
                .WithCity("Brussel");

            var customerDTO = new CustomerDTO_Request()
                .WithFirstName("Jan")
                .WithLastName("Peeters")
                .WithEmail("jan.peeters@email.com")
                .WithPhoneNumber("0470000000")
                .WithAddress(addressDTO);

            return customerDTO;
        }

        [Fact]
        public void ToDTOTest()
        {
            //given
            var addressMapper = new AddressMapper();
            var mapper = new CustomerMapper(addressMapper);

            var customer = InitiateCustomer();

            //when
            var customerDTO = mapper.ToDTO(customer);

            //then
            Assert.Equal(customer.FirstName, customerDTO.FirstName);
            Assert.Equal(customer.LastName, customerDTO.LastName);
            Assert.Equal(customer.Email, customerDTO.Email);
            Assert.Equal(customer.PhoneNumber, customerDTO.PhoneNumber);
            Assert.Equal(customer.Address.StreetName, customerDTO.Address.StreetName);
            Assert.Equal(customer.Address.HouseNumber, customerDTO.Address.HouseNumber);
            Assert.Equal(customer.Address.ZIP, customerDTO.Address.ZIP);
            Assert.Equal(customer.Address.City, customerDTO.Address.City);
        }

        [Fact]
        public void ToDomainTest()
        {
            //given
            var addressMapper = new AddressMapper();
            var mapper = new CustomerMapper(addressMapper);

            var customerDTO = InitiateCustomerDTO();

            //when
            var customer = mapper.ToDomain(customerDTO);

            //then
            Assert.Equal(customer.FirstName, customerDTO.FirstName);
            Assert.Equal(customer.LastName, customerDTO.LastName);
            Assert.Equal(customer.Email, customerDTO.Email);
            Assert.Equal(customer.PhoneNumber, customerDTO.PhoneNumber);
            Assert.Equal(customer.Address.StreetName, customerDTO.Address.StreetName);
            Assert.Equal(customer.Address.HouseNumber, customerDTO.Address.HouseNumber);
            Assert.Equal(customer.Address.ZIP, customerDTO.Address.ZIP);
            Assert.Equal(customer.Address.City, customerDTO.Address.City);
        }
    }
}
