using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Order2.API.Controllers.Orders.DTO.ItemGroup;

namespace Order2.API.Controllers.Orders.DTO.Order
{
    public class OrderDTO_Request
    {
        public int CustomerID { get; set; }
        public List<ItemGroupDTO_Request> ItemGroups { get; set; }

        public OrderDTO_Request WithCustomerID(int customerID)
        {
            CustomerID = customerID;
            return this;
        }

        public OrderDTO_Request WithItemGroups(List<ItemGroupDTO_Request> itemGroupDTOs)
        {
            ItemGroups = itemGroupDTOs;
            return this;
        }
    }
}
