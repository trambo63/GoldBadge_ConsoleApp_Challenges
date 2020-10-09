using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public enum CustomerType { Potential, Current, Past }
    public class Customer
    {
        //A get accessor returns a property value, 
        //and a set accessor assigns a new value.
        //The value keyword represents the value of a property.

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public CustomerType CustomerType { get; set; }
        public string Email { get; set; }

        //A class can have any number of constructors.
        //The main use of constructors is to initialize the 
        //private fields of the class while creating an instance for the class(Seed Data).
        //A constructor doesn't have any return type, not even void.
        //A static constructor can not be a parametrized constructor(this is for myCustomer).
        //within a class, you can create one static constructor only. 
        public Customer() { }


        public Customer(string firstName, string lastName, CustomerType customerType, string email) 
        {
            FirstName = firstName;
            LastName = lastName;
            CustomerType = customerType;
            Email = email;
        }

        public string PotentialCustomerEmail()
        {
            return "We currently have the lowest rates on Helicopter Insurance!";
        }

        public string CurrentCustomerEmail()
        {
            return "Thank you for your work with us. We appreciate your loyalty. Here's a coupon.";
        }

        public string PastCustomerEmail()
        {
            return "It's been a long time since we've heard from you, we want you back.";
        }
    }

}
