using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
        readonly Queue<Claim> _claimQueue = new Queue<Claim>();
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
                Console.WriteLine("Type a number from the menu and press enter: \n" +
                    "1) See all claims \n" +
                    "2) Take care of next claim \n" +
                    "3) Enter a new claim \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllClaims();
                        break;
                    case "2":
                        HandleClaim();
                        break;
                    case "3":
                        EnterClaim();
                        break;
                    case "4":
                        keepThinking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
            }
        }

        private void ShowAllClaims()
        {
            Console.Clear();
            List<Claim> claimList = _claimRepo.GetClaims();
            foreach (Claim claim in claimList)
            {
                Console.WriteLine($"ClaimID: {claim.ClaimID} \n" +
                    $"Claim Type: {claim.ClaimType} \n" +
                    $"Description: {claim.Description} \n" +
                    $"Amount: {claim.ClaimAmount} \n" +
                    $"Date Of Incedent: {claim.DateOfIncident} \n" +
                    $"Date Of Claim: {claim.DateOfClaim} \n" +
                    $"IsVaild: {claim.IsValid}");
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine("No further claims at this time \n");
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void EnterClaim()
        {
            Console.Clear();
            Claim claim = new Claim();
            Console.WriteLine("Enter Claim ID");
            claim.ClaimID = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Claim Type: \n" +
                "1: Car \n" +
                "2: Home \n" +
                "3: Theft");
            string claimTypeResponse = Console.ReadLine();
            switch (claimTypeResponse)
            {
                case "1":
                    claim.ClaimType = ClaimType.Car;
                    break;
                case "2":
                    claim.ClaimType = ClaimType.Home;
                    break;
                case "3":
                    claim.ClaimType = ClaimType.Theft;
                    break;
                default:
                    Console.WriteLine("Invalid");
                    Console.ReadKey();
                    break;
            }
            Console.WriteLine("Enter Claim Description: ");
            claim.Description = Console.ReadLine();
            Console.WriteLine("Enter Claim Amount: ");
            claim.ClaimAmount = Convert.ToDecimal(Console.ReadLine());
            bool keepThinking = true;
            while (keepThinking)
            {
                var dateFormats = new[] { "mm/dd/yyyy" };
                bool isValid = false;

                Console.WriteLine("Enter date of incedent: (mm/dd/yyyy)");
                string dateInput = Console.ReadLine();

                foreach (string dateFormat in dateFormats)
                {
                    DateTime dateToUse;
                    if (DateTime.TryParse(dateInput, out dateToUse))
                    {
                        claim.DateOfIncident = dateToUse;
                        isValid = true;
                    }
                }
                if (isValid == true)
                {
                    keepThinking = false;
                }
                else
                {
                    Console.WriteLine("Ivalid");
                }
                
            }
            bool stillThinking = true;
            while (stillThinking)
            {
                var dateFormats = new[] { "mm/dd/yyyy" };
                bool isValid = false;

                Console.WriteLine("Enter date of Claim: (mm/dd/yyyy)");
                string dateInput = Console.ReadLine();

                foreach (string dateFormat in dateFormats)
                {
                    DateTime dateToUse;
                    if (DateTime.TryParse(dateInput, out dateToUse))
                    {
                        claim.DateOfClaim = dateToUse;
                        isValid = true;
                    }
                }
                if (isValid == true)
                {
                    stillThinking = false;
                }
                else
                {
                    Console.WriteLine("Ivalid");
                }

            }
            var date1 = new DateTime(2020, 8, 1);
            var date2 = new DateTime(2020, 8, 31);
            TimeSpan span1 = date2 - date1;
            //Console.WriteLine($"Control span: {span1}");
            TimeSpan span = claim.DateOfClaim - claim.DateOfIncident;
            //Console.WriteLine($"My Span: {span}");

            if (span <= span1)
            {
                claim.IsValid = true;
            }
            else
            {
                claim.IsValid = false;
            }
            Console.WriteLine(claim.IsValid);
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
            _claimRepo.AddClaim(claim);
        }

        private void HandleClaim()
        {
            Console.Clear();
            _claimQueue.Clear();
            List<Claim> claimList = _claimRepo.GetClaims();
            foreach (Claim claim in claimList)
            {
                _claimQueue.Enqueue(claim);
            }
            bool keepThinking = true;
            while (keepThinking)
            {
                int queueCount = _claimQueue.Count();
                while (queueCount > 0)
                {
                    Console.Clear();
                    Console.WriteLine("Here are the details of the next claim to be handled: \n" +
                        $"ClaimID: {_claimQueue.Peek().ClaimID} \n" +
                        $"Claim Type: {_claimQueue.Peek().ClaimType} \n" +
                        $"Description: {_claimQueue.Peek().Description} \n" +
                        $"Amount: {_claimQueue.Peek().ClaimAmount} \n" +
                        $"Date of Incedent: {_claimQueue.Peek().DateOfIncident} \n" +
                        $"Date of Claim: {_claimQueue.Peek().DateOfClaim} \n" +
                        $"Is Vaild: {_claimQueue.Peek().IsValid}");

                    Console.WriteLine("Do you want to deal with this claim now(y/n)?");
                    string response = Console.ReadLine();
                    if (response.ToLower().Contains("y"))
                    {
                        _claimRepo.HandleClaim(_claimQueue.Dequeue());
                        queueCount -= 1;
                    }
                    if (response.ToLower().Contains("n"))
                    {
                        queueCount = 0;
                    }
                }
                keepThinking = false;
            }
            Console.Clear();
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void SeedData()
        {
            var claim1 = new Claim(1, ClaimType.Car, "car wreck", 200.00m, new DateTime(2020, 08, 25), new DateTime(2020, 08, 26), true);
            var claim2 = new Claim(2, ClaimType.Theft, "Break in", 2000.00m, new DateTime(2020, 07, 13), new DateTime(2020, 07, 14), true);
            _claimRepo.AddClaim(claim1);
            _claimRepo.AddClaim(claim2);
        }
    }
}
