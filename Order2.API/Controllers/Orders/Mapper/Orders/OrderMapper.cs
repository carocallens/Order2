using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order2.API.Controllers.Orders.DTO.Order;
using Order2.API.Controllers.Orders.Mapper.ItemGroups;
using Order2.Domain.Order;

namespace Order2.API.Controllers.Orders.Mapper.Orders
{
    public class OrderMapper : IOrderMapper
    {
        private readonly IItemGroupMapper _itemGroupMapper;

        public OrderMapper(IItemGroupMapper itemGroupMapper)
        {
            _itemGroupMapper = itemGroupMapper;
        }

        public OrderDTO_Response ToDTO(Order order)
        {
            return new OrderDTO_Response()
                .WithOrderID(order.OrderID)
                .WithItemGroups(order.ItemGroups.Select(ig => _itemGroupMapper.ToDTO(ig)).ToList())
                .WithTotalPrice(order.TotalPrice);
        }

        public Order ToDomain(OrderDTO_Request orderDTO)
        {
            return new Order(orderDTO.CustomerID, orderDTO.ItemGroups.Select(ig => _itemGroupMapper.ToDomain(ig)).ToList());
        }
    }
}
