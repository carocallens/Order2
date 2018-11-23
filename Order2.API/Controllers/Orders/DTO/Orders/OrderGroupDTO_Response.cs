using Order2.API.Controllers.Orders.DTO.ItemGroup;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Orders.DTO.Order
{
    public class OrderDTO_Response
    {
        public int OrderID { get; set; }
        public List<ItemGroupDTO_Response> ItemGroups { get; set; }
        public decimal TotalPrice { get; set; }

        public OrderDTO_Response WithOrderID(int id)
        {
            OrderID = id;
            return this;
        }
        public OrderDTO_Response WithItemGroups(List<ItemGroupDTO_Response> itemGroupDTOs)
        {
            ItemGroups = itemGroupDTOs;
            return this;
        }

        public OrderDTO_Response WithTotalPrice(decimal price)
        {
            TotalPrice = price;
            return this;
        }
    }
}
