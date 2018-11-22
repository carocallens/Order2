using Order2.Data;
using Order2.Data.Exception;
using Order2.Domain.Customers;
using Order2.Domain.Exceptions;

namespace Order2.Services.Customers
{
    public class CustomerService : ICustomerService
    {
        private readonly Order2DbContext _context;
        private readonly CustomerValidator _validator;

        public CustomerService(Order2DbContext context, CustomerValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public Customer CreateCustomer(Customer customer)
        {
            if (!_validator.CustomerIsValid(customer))
            {
                throw new InvalidObjectException("The given customer is not valid");
            }

            _context.Customers.Add(customer);
            var success = _context.SaveChanges();

            if (success != 1)
            {
                throw new DatabaseException("We weren't able to save the given customer in the database");
            }

            return customer;
        }
    }
}
