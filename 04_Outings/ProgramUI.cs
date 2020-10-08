using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04_Outings
{
    public class ProgramUI
    {
        private readonly OutingRepo _outingRepo = new OutingRepo();

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
                Console.WriteLine("Type a number from the menu and press enter..... \n" +
                    "1. Show all outings \n" +
                    "2. Add an outing \n" +
                    "3. View Calculations \n" +
                    "4. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllOutings();
                        break;
                    case "2":
                        AddOuting();
                        break;
                    case "3":
                        ShowCosts();
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
        private void ShowAllOutings()
        {
            Console.Clear();
            List<Outing> outingList = _outingRepo.GetAllOutings();
            foreach (var outing in outingList)
            {
                Console.WriteLine($"Event Type: {outing.EventType} \n" +
                    $"Number of Attendees: {outing.NumberOfAttendees} \n" +
                    $"Date of Event: {outing.Date.ToString("dd/mm/yyyy")} \n" +
                    $"Cost per Person: {outing.CostPerPerson} \n" +
                    $"Cost of Event: {outing.CostPerPerson} \n" +
                    "-------------------------------------------------");
            }
            Console.WriteLine("Press any key to contiune...............");
            Console.ReadKey();
        }

        private void AddOuting()
        {
            Console.Clear();
            Outing myOuting = new Outing();
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.WriteLine("What type of Event is do you want to add \n" +
                    "1. Golf \n" +
                    "2. Bowling \n" +
                    "3. Amusement Park \n" +
                    "4. Concert");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        myOuting.EventType = EventType.Golf;
                        break;
                    case "2":
                        myOuting.EventType = EventType.Bowling;
                        break;
                    case "3":
                        myOuting.EventType = EventType.AmusementPark;
                        break;
                    case "4":
                        myOuting.EventType = EventType.Concert;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
                keepThinking = false;
            }
            Console.WriteLine("How many people will attend this event?");
            myOuting.NumberOfAttendees = Convert.ToInt32(Console.ReadLine());
            bool stillThinking = true;
            while (stillThinking)
            {
                var dateFormats = new[] { "mm/dd/yyyy" };
                bool isValid = false;

                Console.WriteLine("Enter the date of the Event: (mm/dd/yyyy)");
                string dateInput = Console.ReadLine();

                foreach (string dateFormat in dateFormats)
                {
                    DateTime dateToUse;
                    if (DateTime.TryParse(dateInput, out dateToUse))
                    {
                        myOuting.Date = dateToUse;
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
            Console.WriteLine("Enter the cost per person: ");
            myOuting.CostPerPerson = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter the cost of the Event: ");
            myOuting.CostOfEvent = Convert.ToDouble(Console.ReadLine());
            _outingRepo.AddOuting(myOuting);
            Console.WriteLine("Press any key to contiune...............");
            Console.ReadKey();

        }

        private void ShowCosts()
        {
            Console.Clear();
            List<double> eventCosts = new List<double>();
            List<Outing> outingList = _outingRepo.GetAllOutings();
            List<double> parkCosts = new List<double>();
            List<double> golfCosts = new List<double>();
            List<double> bowlingCosts = new List<double>();
            List<double> concertCosts = new List<double>();
            foreach (var outing in outingList)
            {
                Console.Clear();
                eventCosts.Add(outing.CostOfEvent);
                if (outing.EventType == EventType.AmusementPark)
                {
                    parkCosts.Add(outing.CostOfEvent);
                }
                if (outing.EventType == EventType.Golf)
                {
                    golfCosts.Add(outing.CostOfEvent);
                }
                if (outing.EventType == EventType.Bowling)
                {
                    bowlingCosts.Add(outing.CostOfEvent);
                }
                if (outing.EventType == EventType.Concert)
                {
                    concertCosts.Add(outing.CostOfEvent);
                }
                Console.WriteLine($"Park cost: {parkCosts.Sum()}");
                Console.WriteLine($"Golf cost: {golfCosts.Sum()}");
                Console.WriteLine($"Bowling cost: {bowlingCosts.Sum()}");
                Console.WriteLine($"Concert cost: {concertCosts.Sum()}");
                Console.WriteLine($"Cost of all Events: {eventCosts.Sum()}");
            }
            Console.WriteLine("Press any key to contiune...............");
            Console.ReadKey();
        }

        private void SeedData()
        {
            var outing1 = new Outing(EventType.AmusementPark, 50, new DateTime(08 / 24 / 2019), 10.00, 400.00);
            var outing2 = new Outing(EventType.Concert, 30, new DateTime(07 / 23 / 2019), 15.00, 200.00);
            var outing3 = new Outing(EventType.Concert, 40, new DateTime(06 / 23 / 2019), 16.00, 150.00);
            _outingRepo.AddOuting(outing1);
            _outingRepo.AddOuting(outing2);
            _outingRepo.AddOuting(outing3);
        }
    }
}
