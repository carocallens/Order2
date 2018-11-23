using Order2.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Services.Items
{
    public interface IItemService
    {
        Item CreateItem(Item item);
    }
}
