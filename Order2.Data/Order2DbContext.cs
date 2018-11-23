using Microsoft.EntityFrameworkCore;
using Order2.Domain;
using Order2.Domain.Customers;
using Order2.Domain.Items;
using Order2.Domain.Order;

namespace Order2.Data
{
    public class Order2DbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Order> Orders { get; set; }

        public Order2DbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LinkCustomerObjectToCustomerTable(modelBuilder);
            LinkItemObjectToItemTable(modelBuilder);
            LinkItemGroupObjectToItemGroupTable(modelBuilder);
            LinkeOrderObjectToOrderTable(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private static void LinkCustomerObjectToCustomerTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", "dbo")
                .HasKey(c => c.CustomerID);

            modelBuilder.Entity<Customer>()
                .Property(c => c.CustomerID).HasColumnName("Customer_ID");
            modelBuilder.Entity<Customer>()
                .Property(c => c.FirstName).HasColumnName("Customer_FirstName");
            modelBuilder.Entity<Customer>()
                .Property(c => c.LastName).HasColumnName("Customer_LastName");
            modelBuilder.Entity<Customer>()
                .Property(c => c.Email).HasColumnName("Customer_Email");
            modelBuilder.Entity<Customer>()
                .Property(c => c.PhoneNumber).HasColumnName("Customer_PhoneNumber");

            modelBuilder.Entity<Customer>()
                .OwnsOne(c => c.Address, a =>
                {
                    a.Property(adr => adr.StreetName).HasColumnName("Customer_StreetName");
                    a.Property(adr => adr.HouseNumber).HasColumnName("Customer_HouseNumber");
                    a.Property(adr => adr.ZIP).HasColumnName("Customer_ZIP");
                    a.Property(adr => adr.City).HasColumnName("Customer_City");
                });

        }

        private static void LinkItemObjectToItemTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>()
                            .ToTable("Items", "dbo")
                            .HasKey(i => i.ItemID);

            modelBuilder.Entity<Item>()
                .Property(i => i.ItemID).HasColumnName("Item_ID");

            modelBuilder.Entity<Item>()
                .Property(i => i.Name).HasColumnName("Item_Name");

            modelBuilder.Entity<Item>()
                .Property(i => i.Description).HasColumnName("Item_Description");

            modelBuilder.Entity<Item>()
                .Property(i => i.Price).HasColumnName("Item_Price");

            modelBuilder.Entity<Item>()
                .Property(i => i.Amount).HasColumnName("Item_Amount");
        }

        private static void LinkeOrderObjectToOrderTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>()
                            .ToTable("Orders", "dbo")
                            .HasKey(o => o.OrderID);

            modelBuilder.Entity<Order>()
                .Property(o => o.OrderID).HasColumnName("Order_ID");
            modelBuilder.Entity<Order>()
                .Property(o => o.CustomerID).HasColumnName("Customer_ID");
            modelBuilder.Entity<Order>()
                .Property(o => o.TotalPrice).HasColumnName("Order_TotalPrice");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerID)
                .IsRequired();

        }

        private static void LinkItemGroupObjectToItemGroupTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ItemGroup>()
                .ToTable("ItemGroups", "dbo")
                .HasKey(ig => ig.ItemGroupID);

            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.ItemGroupID).HasColumnName("ItemGroup_ID");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.OrderID).HasColumnName("Order_ID");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.ItemID).HasColumnName("Item_ID");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.ItemName).HasColumnName("Item_Name");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.AmountOrdered).HasColumnName("Item_Amount");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.ItemPrice).HasColumnName("Item_Price");
            modelBuilder.Entity<ItemGroup>()
                .Property(ig => ig.ShippingDate).HasColumnName("ItemGroup_ShippingDate");

            modelBuilder.Entity<ItemGroup>()
                .HasOne(ig => ig.Item)
                .WithMany()
                .HasForeignKey(ig => ig.ItemID)
                .IsRequired();

            modelBuilder.Entity<ItemGroup>()
                .HasOne(ig => ig.Order)
                .WithMany(o => o.ItemGroups)
                .HasForeignKey(ig => ig.OrderID)
                .IsRequired();


        }
    }
}
