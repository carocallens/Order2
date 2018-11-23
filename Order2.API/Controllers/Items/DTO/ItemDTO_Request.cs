using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Items.DTO
{
    public class ItemDTO_Request
    {
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemAmount { get; set; }

        public ItemDTO_Request WithName(string name)
        {
            ItemName = name;
            return this;
        }

        public ItemDTO_Request WithDescription(string description)
        {
            ItemDescription = description;
            return this;
        }

        public ItemDTO_Request WithPrice(decimal price)
        {
            ItemPrice = price;
            return this;
        }

        public ItemDTO_Request WithAmount(int amount)
        {
            ItemAmount = amount;
            return this;
        }
    }
}
