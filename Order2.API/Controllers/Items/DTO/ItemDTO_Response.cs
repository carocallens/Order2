using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Items.DTO
{
    public class ItemDTO_Response
    { 
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }
        public string ItemDescription { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int ItemAmount { get; private set; }

        public ItemDTO_Response WithId(int id)
        {
            ItemID = id;
            return this;
        }

        public ItemDTO_Response WithName(string name)
        {
            ItemName = name;
            return this;
        }

        public ItemDTO_Response WithDescription(string description)
        {
            ItemDescription = description;
            return this;
        }

        public ItemDTO_Response WithPrice(decimal price)
        {
            ItemPrice = price;
            return this;
        }

        public ItemDTO_Response WithAmount(int amount)
        {
            ItemAmount = amount;
            return this;
        }
    }
}
