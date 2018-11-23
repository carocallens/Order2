using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Domain.Items
{
    public class Item
    {
        public int ItemID { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

        private Item() { }
        public Item(ItemBuilder itemBuilder)
        {
            Name = itemBuilder.Name;
            Description = itemBuilder.Description;
            Price = itemBuilder.Price;
            Amount = itemBuilder.Amount;
        }

    }

    public class ItemBuilder
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Amount { get; private set; }

        private ItemBuilder() { }

        public static ItemBuilder CreateItem()
        {
            return new ItemBuilder();
        }

        public Item Build()
        {
            return new Item(this);
        }

        public ItemBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        public ItemBuilder WithDescription(string description)
        {
            Description = description;
            return this;
        }

        public ItemBuilder WithPrice(decimal price)
        {
            Price = price;
            return this;
        }

        public ItemBuilder WithAmount(int amount)
        {
            Amount = amount;
            return this;
        }

    }
}
