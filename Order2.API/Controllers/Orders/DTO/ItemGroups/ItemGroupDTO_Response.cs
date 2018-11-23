using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Orders.DTO.ItemGroup
{
    public class ItemGroupDTO_Response
    {
        public string ItemName { get; set; }
        public decimal ItemPrice { get; set; }
        public int AmountOrdered { get; set; }
        public DateTime ShippingDate { get; set; }

        public ItemGroupDTO_Response WithItemName(string name)
        {
            ItemName = name;
            return this;
        }

        public ItemGroupDTO_Response WithItemPrice(decimal price)
        {
            ItemPrice= price;
            return this;
        }

        public ItemGroupDTO_Response WithAmountOrdered(int amount)
        {
            AmountOrdered = amount;
            return this;
        }

        public ItemGroupDTO_Response WithShippingDate(DateTime date)
        {
            ShippingDate = date;
            return this;
        }
    }
}
