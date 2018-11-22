using System;
using System.Collections.Generic;
using System.Text;
using Order2.Domain.Customers.Addresses;

namespace Order2.Domain.Customers
{
    public class Customer
    {
        public int CustomerID { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        private Customer() { }

        public Customer(CustomerBuilder customerBuilder)
        {
            FirstName = customerBuilder.FirstName;
            LastName = customerBuilder.LastName;
            Address = customerBuilder.Address;
            Email = customerBuilder.Email;
            PhoneNumber = customerBuilder.PhoneNumber;

        }
    }

    public class CustomerBuilder
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public Address Address { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public static CustomerBuilder CreateCustomer()
        {
            return new CustomerBuilder();
        }

        public Customer Build()
        {
            return new Customer(this);
        }

        public CustomerBuilder WithFirstName(string firstName)
        {
            FirstName = firstName;
            return this;
        }

        public CustomerBuilder WithLastName(string lastName)
        {
            LastName = lastName;
            return this;
        }

        public CustomerBuilder WithAddress(Address address)
        {
            Address = address;
            return this;
        }

        public CustomerBuilder WithEmail(string email)
        {
            Email = email;
            return this;
        }

        public CustomerBuilder WithPhoneNumber(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
            return this;
        }
    }
}
