using Order2.API.Controllers.Items.DTO;
using Order2.API.Controllers.Items.Mapper;
using Order2.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Order2.API.Tests.Items
{
    public class ItemMapperTests
    {

        public Item InitiateItem()
        {
            return ItemBuilder.CreateItem()
                .WithName("Xbox")
                .WithDescription("Black")
                .WithPrice(250)
                .WithAmount(25)
                .Build();
        }

        public ItemDTO_Request InitiateItemDTO()
        {
            return new ItemDTO_Request()
                .WithName("Xbox")
                .WithDescription("Black")
                .WithPrice(250)
                .WithAmount(25);
        }
        [Fact]
        public void ToDomainTest()
        {
            //given
            var mapper = new ItemMapper();
            var itemDTO = InitiateItemDTO();

            //when
            var item = mapper.ToDomain(itemDTO);

            //then
            Assert.Equal(itemDTO.ItemName, item.Name);
            Assert.Equal(itemDTO.ItemDescription, item.Description);
            Assert.Equal(itemDTO.ItemPrice, item.Price);
            Assert.Equal(itemDTO.ItemAmount, item.Amount);
        }

        [Fact]
        public void ToDTOTest()
        {
            //given
            var mapper = new ItemMapper();
            var item = InitiateItem();

            //when
            var itemDTO = mapper.ToDTO(item);

            //then
            Assert.Equal(itemDTO.ItemName, item.Name);
            Assert.Equal(itemDTO.ItemDescription, item.Description);
            Assert.Equal(itemDTO.ItemPrice, item.Price);
            Assert.Equal(itemDTO.ItemAmount, item.Amount);
        }
    }
}
