using Order2.API.Controllers.Orders.DTO.ItemGroup;
using Order2.API.Controllers.Orders.DTO.Order;
using Order2.API.Controllers.Orders.Mapper.ItemGroups;
using Order2.API.Controllers.Orders.Mapper.Orders;
using Order2.Domain.Order;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Order2.API.Tests.Orders
{
    public class OrderMapperTests
    {
      
        private List<ItemGroup> InitiateItemGroups()
        {
            var itemgroup1 = ItemGroupBuilder.CreateItemGroup()
                .WithItemID(1)
                .WithItemName("PS4")
                .WithItemPrice(250)
                .WithAmountOrdered(3)
                .Build();
            
            var itemgroup2 = ItemGroupBuilder.CreateItemGroup()
                .WithItemID(2)
                .WithItemName("Nintendo Switch")
                .WithItemPrice(150)
                .WithAmountOrdered(3)
                .Build();

            return new List<ItemGroup>
            {
                itemgroup1,
                itemgroup2
            };
        }


        private Order InitiateOrder()
        {
            return new Order(InitiateItemGroups());
        }

        private List<ItemGroupDTO_Request> InitiateItemGroupDTOs()
        {
            var itemgroup1 = new ItemGroupDTO_Request()
                .WithItemID(1)
                .WithAmountOrdered(3);

            var itemgroup2 = new ItemGroupDTO_Request()
                .WithItemID(2)
                .WithAmountOrdered(3);

            return new List<ItemGroupDTO_Request>()
            {
                itemgroup1,
                itemgroup2
            };
        }

        private OrderDTO_Request InitiateOrderDTO()
        {
            return new OrderDTO_Request()
                .WithItemGroups(InitiateItemGroupDTOs());
        }

        [Fact]
        public void ToDomainTest()
        {
            //given
            var mapper = new OrderMapper(new ItemGroupMapper());
            var orderDTO = InitiateOrderDTO();

            //when
            var order = mapper.ToDomain(orderDTO);

            //then
            Assert.Equal(orderDTO.ItemGroups.Count, order.ItemGroups.Count);
        }

        [Fact]
        public void ToDTOTest()
        {
            //given
            var mapper = new OrderMapper(new ItemGroupMapper());
            var order = InitiateOrder();

            //when
            var orderDTO = mapper.ToDTO(order);

            //then
            Assert.Equal(orderDTO.ItemGroups.Count, order.ItemGroups.Count);
        }


    }
}
