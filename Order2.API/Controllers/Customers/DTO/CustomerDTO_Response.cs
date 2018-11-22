using Order2.API.Controllers.Customers.DTO.Address;

namespace Order2.API.Controllers.Customers.DTO
{
    public class CustomerDTO_Response
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public AddressDTO Address { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }

        public CustomerDTO_Response WithCustomerID(int ID)
        {
            CustomerID = ID;
            return this;
        }

        public CustomerDTO_Response WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CustomerDTO_Response WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CustomerDTO_Response WithAddress(AddressDTO address)
        {
            Address = address;
            return this;
        }

        public CustomerDTO_Response WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerDTO_Response WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }
    }
}

