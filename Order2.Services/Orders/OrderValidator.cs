using Order2.Domain.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Services.Orders
{
    public class OrderValidator
    {
        public static bool OrderIsValid(Order order)
        {
            if(order.ItemGroups.Count == 0 ||
                order.TotalPrice < 0)
            {
                return false;
            }

            return true;
        }
    }
}
