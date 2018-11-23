using Order2.API.Controllers.Items.DTO;
using Order2.Domain.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Items.Mapper
{
    public interface IItemMapper
    {
        Item ToDomain(ItemDTO_Request itemDTO);
        ItemDTO_Response ToDTO(Item item);
    }
}
