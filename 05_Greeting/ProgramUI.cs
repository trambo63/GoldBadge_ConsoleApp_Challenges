using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05_Greeting
{
    public class ProgramUI
    {
        private readonly CustomerRepo _customerRepo = new CustomerRepo();

        public void Run()
        {
            SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.Clear();
                Console.WriteLine("Type a number from the menu and press enter......\n" +
                    "1. View all emails \n" +
                    "2. Add an email \n" +
                    "3. Edit an email \n" +
                    "4. Delete an email \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllEmails();
                        break;
                    case "2":
                        AddNewEmail();
                        break;
                    case "3":
                        //EditEmail();
                        break;
                    case "4":
                        //DeleteEmail();
                        break;
                    case "5":
                        keepThinking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
            }

        }
        private void ShowAllEmails()
        {
            Console.Clear();
            List<Customer> customers = _customerRepo.GetAllEmails();
            foreach (var customer in customers)
            {
                Console.WriteLine($"Name: {customer.FirstName} {customer.LastName} \n" +
                    $"Type: {customer.CustomerType} \n" +
                    $"Email: {customer.Email} \n" +
                    "-----------------------------------------------------------");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void AddNewEmail()
        {
            Console.Clear();
            Customer myCustomer = new Customer();
            Console.WriteLine("First Name: ");
            myCustomer.FirstName = Console.ReadLine();
            Console.WriteLine("Last Name");
            myCustomer.LastName = Console.ReadLine();
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.WriteLine("Customer Type.....\n" +
                    "1. Current \n" +
                    "2. Past \n" +
                    "3. Potential");
                string userResponse = Console.ReadLine();
                switch (userResponse)
                {
                    case "1":
                        myCustomer.CustomerType = CustomerType.Current;
                        myCustomer.Email = myCustomer.CurrentCustomerEmail();
                        break;
                    case "2":
                        myCustomer.CustomerType = CustomerType.Past;
                        myCustomer.Email = myCustomer.PastCustomerEmail();
                        break;
                    case "3":
                        myCustomer.CustomerType = CustomerType.Potential;
                        myCustomer.Email = myCustomer.PotentialCustomerEmail();
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
                keepThinking = false;
            }
            _customerRepo.AddEmail(myCustomer);
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void SeedData()
        {
            Customer myCustomer = new Customer();
            var customer1 = new Customer("Jim", "Brown", CustomerType.Current, myCustomer.CurrentCustomerEmail());
            var customer2 = new Customer("Bernie", "Kosr", CustomerType.Past, myCustomer.PastCustomerEmail());
            var customer3 = new Customer("Lou", "Groza", CustomerType.Past, myCustomer.PastCustomerEmail());
            _customerRepo.AddEmail(customer1);
            _customerRepo.AddEmail(customer2);
            _customerRepo.AddEmail(customer3);
        }
    }
}
