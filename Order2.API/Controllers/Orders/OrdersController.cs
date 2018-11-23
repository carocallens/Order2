using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order2.API.Controllers.Orders.DTO.Order;
using Order2.API.Controllers.Orders.Mapper.Orders;
using Order2.Services.Orders;

namespace Order2.API.Controllers.Orders
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderMapper _orderMapper;
        private readonly IOrderService _orderService;

        public OrdersController(IOrderMapper orderMapper, IOrderService orderService)
        {
            _orderMapper = orderMapper;
            _orderService = orderService;
        }

        [HttpPost]
        public ActionResult<OrderDTO_Response> CreateOrder([FromBody] OrderDTO_Request orderDTO)
        {
            //try
            //{
                var order = _orderService.CreateOrder(_orderMapper.ToDomain(orderDTO));
                return Ok(_orderMapper.ToDTO(order));
            //}
            //catch (Exception e)
            //{
            //    return BadRequest(e.Message);
            //}
        }
    }
}