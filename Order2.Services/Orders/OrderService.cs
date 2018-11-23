using Order2.Data;
using Order2.Data.Exception;
using Order2.Domain.Exceptions;
using Order2.Domain.Items;
using Order2.Domain.Order;
using Order2.Services.Customers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Order2.Services.Orders
{
    public class OrderService : IOrderService
    {
        private readonly ICustomerService _customerService;
        private readonly Order2DbContext _context;

        public OrderService(ICustomerService customerService, Order2DbContext context)
        {
            this._customerService = customerService;
            _context = context;
        }

        public Order CreateOrder(Order order)
        {
            if(_customerService.GetCustomer(order.CustomerID) == null)
            {
                throw new ObjectNotFoundException("The given customer does not exist");
            }

            if (!OrderValidator.OrderIsValid(order))
            {
                throw new InvalidObjectException("The given order was not valid");
            }

            var completedOrder = FillInItemGroupsFromOrder(order);

            _context.Orders.Add(completedOrder);
            _context.SaveChanges();

            return completedOrder;
            
        }

        private Order FillInItemGroupsFromOrder(Order order)
        {
            order.ItemGroups.ForEach(ig => FillInItemGroup(ig, order.OrderID));

            return order;
        }

        private void FillInItemGroup(ItemGroup ig, int orderID)
        {
            var item = _context.Items.FirstOrDefault(i => i.ItemID == ig.ItemID);

            ig = ItemGroupBuilder.CreateItemGroup()
                .WithOrderID(orderID)
                .WithItemID(item.ItemID)
                .WithItemName(item.Name)
                .WithItemPrice(item.Price)
                .WithAmountOrdered(ig.AmountOrdered)
                .WithShippingDate(CalculateShippingDate(ig, item))
                .Build();
        }

        private DateTime CalculateShippingDate(ItemGroup itemgroup, Item item)
        {
            if (item.Amount - itemgroup.AmountOrdered > 0)
            {
                return DateTime.Now.AddDays(1);
            }
            else
                return DateTime.Now.AddDays(7);
        }
    }
}
