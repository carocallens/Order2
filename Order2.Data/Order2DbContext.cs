using Microsoft.EntityFrameworkCore;
using Order2.Domain;
using Order2.Domain.Customers;

namespace Order2.Data
{
    public class Order2DbContext : DbContext
    {
        public virtual DbSet<Customer> Customers { get; set; }

        public Order2DbContext(DbContextOptions options): base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LinkCustomerObjectToCustomerTable(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void LinkCustomerObjectToCustomerTable(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .ToTable("Customers", "cus")
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
    }
}
