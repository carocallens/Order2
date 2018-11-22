using Order2.Domain.Customers;
using System.Net.Mail;

namespace Order2.Services.Customers
{
    public class CustomerValidator
    {
        public bool CustomerIsValid(Customer customer)
        {
            if (customer == null ||
                string.IsNullOrWhiteSpace(customer.FirstName) ||
                string.IsNullOrWhiteSpace(customer.LastName) ||
                !IsValidEmail(customer.Email) ||
                string.IsNullOrWhiteSpace(customer.PhoneNumber) ||
                customer.Address == null ||
                string.IsNullOrWhiteSpace(customer.Address.StreetName) ||
                string.IsNullOrWhiteSpace(customer.Address.HouseNumber) ||
                string.IsNullOrWhiteSpace(customer.Address.ZIP) ||
                string.IsNullOrWhiteSpace(customer.Address.City))
            {
                return false;
            }

            return true;
        }

        private static bool IsValidEmail(string email)
        {
            try
            {
                MailAddress m = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
