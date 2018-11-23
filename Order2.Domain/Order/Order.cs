using Order2.Domain.Customers;
using System.Collections.Generic;

namespace Order2.Domain.Order
{
    public class Order
    {
        public int OrderID { get; private set; }
        public int CustomerID { get; private set; }
        public Customer Customer { get; private set; }
        public List<ItemGroup> ItemGroups { get; private set; } = new List<ItemGroup>();
        public decimal TotalPrice { get; private set; }


        public Order() { }

        public Order(int customerID, List<ItemGroup> itemGroups)
        {
            CustomerID = customerID;

            ItemGroups = itemGroups;

            TotalPrice = CalculateTotalPriceOrder(itemGroups);
        }

        private static decimal CalculateTotalPriceOrder(List<ItemGroup> itemGroups)
        {
            var totalPrice = 0m;

            foreach (var itemGroup in itemGroups)
            {
                totalPrice += itemGroup.ItemPrice * itemGroup.AmountOrdered;
            }

            return totalPrice;
        }
    }
}
