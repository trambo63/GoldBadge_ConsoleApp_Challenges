using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_Claims
{
    public class ProgramUI
    {
        private readonly ClaimRepo _claimRepo = new ClaimRepo();
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
                        //ResolveNextClaim();
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
                    $"Claim Type: {claim.ClaimID} \n" +
                    $"Description: {claim.Description} \n" +
                    $"Amount: {claim.ClaimAmount} \n" +
                    $"Date Of Incedent: {claim.DateOfIncident} \n" +
                    $"Date Of Claim: {claim.DateOfClaim} \n" +
                    $"IsVaild: {claim.IsValid}");
                Console.WriteLine("------------------------------");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void EnterClaim()
        {
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
            bool thinking = true;
            while (thinking)
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
                    thinking = false;
                }
                else
                {
                    Console.WriteLine("Ivalid");
                }
                
            }
            Console.WriteLine("Enter date of claim: (mm/dd/yyyy)");
            claim.DateOfClaim = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Is the claim valid: \n" +
                "1: Yes \n" +
                "2: No");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    claim.IsValid = true;
                    break;
                case "2":
                    claim.IsValid = false;
                    break;
                default:
                    Console.WriteLine("Invalid");
                    Console.ReadKey();
                    break;
            }
            _claimRepo.AddClaim(claim);
        }

        private void SeedData()
        {
            var claim1 = new Claim(1, ClaimType.Car, "car wreck", 200.00m, DateTime.Now, DateTime.Now, true);
            _claimRepo.AddClaim(claim1);
        }
    }
}
