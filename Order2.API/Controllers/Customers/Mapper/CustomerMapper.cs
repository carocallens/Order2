using Order2.API.Controllers.Customers.DTO;
using Order2.API.Controllers.Customers.Mapper.Addresses;
using Order2.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers.Mapper
{
    public class CustomerMapper : ICustomerMapper
    {
        private readonly IAddressMapper _addressMapper;

        public CustomerMapper(IAddressMapper addressMapper)
        {
            _addressMapper = addressMapper;
        }

        public Customer ToDomain(CustomerDTO_Request customerDTO)
        {
            return CustomerBuilder.CreateCustomer()
                .WithFirstName(customerDTO.FirstName)
                .WithLastName(customerDTO.LastName)
                .WithAddress(_addressMapper.ToDomain(customerDTO.Address))
                .WithEmail(customerDTO.Email)
                .WithPhoneNumber(customerDTO.PhoneNumber)
                .Build();
        }

        public CustomerDTO_Response ToDTO(Customer customer)
        {
            return new CustomerDTO_Response()
                .WithCustomerID(customer.CustomerID)
                .WithFirstName(customer.FirstName)
                .WithLastName(customer.LastName)
                .WithAddress(_addressMapper.ToDTO(customer.Address))
                .WithEmail(customer.Email)
                .WithPhoneNumber(customer.PhoneNumber);
        }
    }
}
