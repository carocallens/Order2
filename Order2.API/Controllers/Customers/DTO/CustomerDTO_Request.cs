using Order2.API.Controllers.Customers.DTO.Address;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order2.API.Controllers.Customers.DTO
{
    public class CustomerDTO_Request
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerDTO_Request WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CustomerDTO_Request WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CustomerDTO_Request WithAddress(AddressDTO address)
        {
            Address = address;
            return this;
        }

        public CustomerDTO_Request WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerDTO_Request WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }
    }
}
