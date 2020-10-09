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


    }
}
