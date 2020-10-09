using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class CustomerRepo : Customer
    {
        protected readonly List<Customer> _customerDB = new List<Customer>();

        public bool AddEmail(Customer customer)
        {
            int startingCount = _customerDB.Count();
            _customerDB.Add(customer);
            bool wasAdded = (_customerDB.Count() > startingCount) ? true : false;
            return wasAdded;
        }

        public List<Customer> GetAllEmails()
        {
            return _customerDB;
        }

        public Customer GetCustomerByName(string fistName)
        {
            foreach (Customer customer in _customerDB)
            {
                if (customer.FirstName.ToLower() == fistName.ToLower())
                {
                    return customer;
                }
            }
            return null;
        }

        public bool EditCustomer(string originalFirstName, Customer newCustomer)
        {
            Customer oldCustomer = GetCustomerByName(originalFirstName);

            if (oldCustomer != null)
            {
                oldCustomer.FirstName = newCustomer.FirstName;
                oldCustomer.LastName = newCustomer.LastName;
                oldCustomer.CustomerType = newCustomer.CustomerType;
                oldCustomer.Email = newCustomer.Email;

                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteCustomer(Customer customer)
        {
            bool deleteResult = _customerDB.Remove(customer);
            return deleteResult;
        }

    }
}
