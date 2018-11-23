using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order2.API.Controllers.Orders.DTO.ItemGroup;
using Order2.Domain.Order;

namespace Order2.API.Controllers.Orders.Mapper.ItemGroups
{
    public class ItemGroupMapper : IItemGroupMapper
    {
        public ItemGroup ToDomain(ItemGroupDTO_Request itemGroupDTO)
        {
            return ItemGroupBuilder.CreateItemGroup()
                .WithItemID(itemGroupDTO.ItemID)
                .WithAmountOrdered(itemGroupDTO.AmountOrdered)
                .Build();
        }

        public ItemGroupDTO_Response ToDTO(ItemGroup itemGroup)
        {
            return new ItemGroupDTO_Response()
                .WithItemName(itemGroup.ItemName)
                .WithItemPrice(itemGroup.ItemPrice)
                .WithAmountOrdered(itemGroup.AmountOrdered)
                .WithShippingDate(itemGroup.ShippingDate);
        }
    }
}
