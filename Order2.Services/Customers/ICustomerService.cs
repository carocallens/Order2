using Order2.Domain.Customers;
using System;
using System.Collections.Generic;
using System.Text;

namespace Order2.Services.Customers
{
    public interface ICustomerService
    {
        Customer CreateCustomer(Customer customer);
        Customer GetCustomer(int id);
        List<Customer> GetAllCustomers();
    }
}
