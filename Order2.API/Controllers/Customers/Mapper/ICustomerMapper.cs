using Order2.API.Controllers.Customers.DTO;
using Order2.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers.Mapper
{
    public interface ICustomerMapper
    {
        Customer ToDomain(CustomerDTO_Request customerDTO);
        CustomerDTO_Response ToDTO(Customer customer);
    }
}
