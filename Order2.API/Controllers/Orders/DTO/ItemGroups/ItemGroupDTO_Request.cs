using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Orders.DTO.ItemGroup
{
    public class ItemGroupDTO_Request
    {
        public int ItemID { get; set; }
        public int AmountOrdered { get; set; }

        public ItemGroupDTO_Request WithItemID(int id)
        {
            ItemID = id;
            return this;
        }

        public ItemGroupDTO_Request WithAmountOrdered(int amount)
        {
            AmountOrdered = amount;
            return this;
        }
    }
}
