using Order2.API.Controllers.Orders.DTO.Order;
using Order2.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Orders.Mapper.Orders
{
    public interface IOrderMapper
    {
        OrderDTO_Response ToDTO(Order order);
        Order ToDomain(OrderDTO_Request orderDTO);
    }
}
