using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order2.API.Controllers.Items.DTO;
using Order2.Domain.Items;

namespace Order2.API.Controllers.Items.Mapper
{
    public class ItemMapper : IItemMapper
    {
        public Item ToDomain(ItemDTO_Request itemDTO)
        {
            return ItemBuilder.CreateItem()
                .WithName(itemDTO.ItemName)
                .WithDescription(itemDTO.ItemDescription)
                .WithPrice(itemDTO.ItemPrice)
                .WithAmount(itemDTO.ItemAmount)
                .Build();
        }

        public ItemDTO_Response ToDTO(Item item)
        {
            return new ItemDTO_Response()
                .WithId(item.ItemID)
                .WithName(item.Name)
                .WithDescription(item.Description)
                .WithPrice(item.Price)
                .WithAmount(item.Amount);
        }
    }
}
