using Microsoft.AspNetCore.Mvc;
using Order2.API.Controllers.Customers.DTO;
using Order2.API.Controllers.Customers.Mapper;
using Order2.Services.Customers;
using System;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerMapper _customerMapper;
        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerMapper customerMapper, ICustomerService customerService)
        {
            _customerMapper = customerMapper;
            _customerService = customerService;
        }

        [HttpPost]
        public ActionResult<CustomerDTO_Response> CreateCustomer([FromBody] CustomerDTO_Request customerDTO)
        {
            try
            {
                var customer = _customerService.CreateCustomer(_customerMapper.ToDomain(customerDTO));
                return Ok(_customerMapper.ToDTO(customer));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}