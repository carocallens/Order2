using Order2.API.Controllers.Orders.DTO.ItemGroup;
using Order2.API.Controllers.Orders.Mapper;
using Order2.API.Controllers.Orders.Mapper.ItemGroups;
using Order2.Domain.Order;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Order2.API.Tests.Orders
{
    public class ItemGroupMapperTests
    {
        private ItemGroup InitiateItemGroup()
        {
            return ItemGroupBuilder.CreateItemGroup()
                .WithItemID(1)
                .WithItemName("PS4")
                .WithItemPrice(250)
                .WithAmountOrdered(3)
                .Build();
        }

        private ItemGroupDTO_Request InitiateItemGroupDTO()
        {
            return new ItemGroupDTO_Request()
                .WithItemID(1)
                .WithAmountOrdered(3);
        }

        [Fact]
        public void ToDomainTest()
        {
            //given
            var mapper = new ItemGroupMapper();
            var itemGroupDTO = InitiateItemGroupDTO();

            //when
            var itemGroup = mapper.ToDomain(itemGroupDTO);

            //then
            Assert.Equal(itemGroup.ItemID, itemGroupDTO.ItemID);
            Assert.Equal(itemGroup.AmountOrdered, itemGroupDTO.AmountOrdered);
        }

        [Fact]
        public void ToDTOTest()
        {
            //given
            var mapper = new ItemGroupMapper();
            var itemGroup = InitiateItemGroup();

            //when
            var itemGroupDTO = mapper.ToDTO(itemGroup);

            //then
            Assert.Equal(itemGroup.ItemName, itemGroupDTO.ItemName);
            Assert.Equal(itemGroup.ItemPrice, itemGroupDTO.ItemPrice);
            Assert.Equal(itemGroup.AmountOrdered, itemGroupDTO.AmountOrdered);
        }
    }
}
