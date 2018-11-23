using Order2.Domain.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Domain.Order
{
    public class ItemGroup
    {
        public int? ItemGroupID { get; private set; }
        public int OrderID { get; set; }
        public Order Order { get; private set; }
        public int ItemID { get; private set; }
        public Item Item { get; private set; }
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int AmountOrdered { get; private set; }
        public DateTime ShippingDate { get; private set; }

        private ItemGroup() { }
    
        public ItemGroup(ItemGroupBuilder itemGroupBuilder)
        {
            OrderID = itemGroupBuilder.OrderID;
            ItemID = itemGroupBuilder.ItemID;
            ItemName = itemGroupBuilder.ItemName;
            ItemPrice = itemGroupBuilder.ItemPrice;
            AmountOrdered = itemGroupBuilder.AmountOrdered;
            ShippingDate = itemGroupBuilder.ShippingDate;
        }
    }

    public class ItemGroupBuilder
    {
        public int OrderID { get; private set; }
        public int ItemID { get; private set; }
        public string ItemName { get; private set; }
        public decimal ItemPrice { get; private set; }
        public int AmountOrdered { get; private set; }
        public DateTime ShippingDate { get; private set; }

        private ItemGroupBuilder() { }

        public static ItemGroupBuilder CreateItemGroup()
        {
            return new ItemGroupBuilder();
        }

        public ItemGroup Build()
        {
            return new ItemGroup(this);
        }

        public ItemGroupBuilder WithOrderID(int id)
        {
            OrderID = id;
            return this;
        }
        public ItemGroupBuilder WithItemID(int id)
        {
            ItemID = id;
            return this;
        }

        public ItemGroupBuilder WithItemName(string name)
        {
            ItemName = name;
            return this;
        }

        public ItemGroupBuilder WithItemPrice(decimal price)
        {
            ItemPrice = price;
            return this;
        }

        public ItemGroupBuilder WithAmountOrdered(int amount)
        {
            AmountOrdered = amount;
            return this;
        }

        public ItemGroupBuilder WithShippingDate(DateTime date)
        {
            ShippingDate = date;
            return this;
        }

    }
}
