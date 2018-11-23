using Order2.API.Controllers.Orders.DTO.ItemGroup;
using Order2.Domain.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Orders.Mapper.ItemGroups
{
    public interface IItemGroupMapper
    {
        ItemGroup ToDomain(ItemGroupDTO_Request itemGroupDTO);
        ItemGroupDTO_Response ToDTO(ItemGroup itemGroup);
    }
}
