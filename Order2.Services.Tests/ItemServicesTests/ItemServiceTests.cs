using Microsoft.EntityFrameworkCore;
using Order2.Data;
using Order2.Domain.Items;
using Order2.Services.Items;
using System;
using Xunit;

namespace Order2.Services.Tests.ItemServicesTests
{
    public class ItemServiceTests
    {
        private static DbContextOptions CreateNewInMemoryDatabase()
        {
            return new DbContextOptionsBuilder<Order2DbContext>()
                .UseInMemoryDatabase("Order2Db" + Guid.NewGuid().ToString("N"))
                .Options;
        }

        private Item InitiateItem()
        {
            return ItemBuilder.CreateItem()
                .WithName("Xbox")
                .WithDescription("Black")
                .WithPrice(250)
                .WithAmount(15)
                .Build();
        }

        [Fact]
        public void CreateService_HappyPath()
        {
            using (var context = new Order2DbContext(CreateNewInMemoryDatabase()))
            {
                var item = InitiateItem();
                
                var service = new ItemService(context);

                var result = service.CreateItem(item);

                Assert.IsType<Item>(result);
            }
        }
    }
}
