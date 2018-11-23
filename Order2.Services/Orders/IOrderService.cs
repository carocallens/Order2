using Order2.Domain.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Services.Orders
{
    public interface IOrderService
    {
        Order CreateOrder(Order order);
    }
}
