using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class ProgramUI
    {
        private readonly CarRepo _carRepo = new CarRepo();
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
                Console.WriteLine("Type a number from the menu and press enter.........\n" +
                    "1. See all cars \n" +
                    "2. Add a car \n" +
                    "3. Update a car \n" +
                    "4. Delete a car \n" +
                    "5. Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        ShowAllCars();
                        break;
                    case "2":
                        AddNewCar();
                        break;
                    case "3":
                        //UpdateCar();
                        break;
                    case "4":
                        //DeleteCar();
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

        private void ShowAllCars()
        {
            Console.Clear();
            List<Car> carList = _carRepo.GetAllCars();
            foreach (var car in carList)
            {
                Console.WriteLine($"Type: {car.CarType} \n" +
                    $"Average Cost: {car.AverageCost} \n" +
                    $"Safety Rating: {car.SateyRating} \n" +
                    $"Fuel Efficiency Rating: {car.FuelEfficiencyRating} \n" +
                    "-------------------------------------------------");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void AddNewCar()
        {
            Console.Clear();
            Car myCar = new Car();
            bool menu1 = true;
            while (menu1)
            {
                Console.WriteLine("What Type of Car is it: \n" +
                    "1. Electric \n" +
                    "2. Gas \n" +
                    "3. Hybrid");
                string userInput1 = Console.ReadLine();
                switch (userInput1)
                {
                    case "1":
                        myCar.CarType = CarType.Electric;
                        break;
                    case "2":
                        myCar.CarType = CarType.Gas;
                        break;
                    case "3":
                        myCar.CarType = CarType.Hybrid;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
                menu1 = false;
            }
            Console.WriteLine("What is the average cost: ");
            myCar.AverageCost = Convert.ToDouble(Console.ReadLine());
            bool menu2 = true;
            while (menu2)
            {
                Console.WriteLine("What Safety Rating is it: \n" +
                    "1. One Star \n" +
                    "2. Two Star \n" +
                    "3. Three Star \n" +
                    "4. Four Star \n" +
                    "5. Five Star");
                string userInput2 = Console.ReadLine();
                switch (userInput2)
                {
                    case "1":
                        myCar.SateyRating = SateyRating.One_Star;
                        break;
                    case "2":
                        myCar.SateyRating = SateyRating.Two_Star;
                        break;
                    case "3":
                        myCar.SateyRating = SateyRating.Three_Star;
                        break;
                    case "4":
                        myCar.SateyRating = SateyRating.Four_Star;
                        break;
                    case "5":
                        myCar.SateyRating = SateyRating.Five_Star;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
                menu2 = false;
            }
            bool menu3 = true;
            while (menu3)
            {
                Console.WriteLine("What Fuel Efficiency is it: \n" +
                    "1. Poor \n" +
                    "2. Fair \n" +
                    "3. Goood \n" +
                    "4. Excellent");
                string userInput3 = Console.ReadLine();
                switch (userInput3)
                {
                    case "1":
                        myCar.FuelEfficiencyRating = FuelEfficiencyRating.Poor;
                        break;
                    case "2":
                        myCar.FuelEfficiencyRating = FuelEfficiencyRating.Fair;
                        break;
                    case "3":
                        myCar.FuelEfficiencyRating = FuelEfficiencyRating.Good;
                        break;
                    case "4":
                        myCar.FuelEfficiencyRating = FuelEfficiencyRating.Excellent;
                        break;
                    default:
                        Console.WriteLine("Invalid");
                        Console.ReadKey();
                        break;
                }
                menu3 = false;
            }
            _carRepo.AddCar(myCar);
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void SeedData()
        {
            var car1 = new Car(CarType.Electric, 55.600, SateyRating.Four_Star, FuelEfficiencyRating.Excellent);
            var car2 = new Car(CarType.Gas, 20.000, SateyRating.Five_Star, FuelEfficiencyRating.Fair);
            var car3 = new Car(CarType.Hybrid, 23.000, SateyRating.Five_Star, FuelEfficiencyRating.Excellent);
            _carRepo.AddCar(car1);
            _carRepo.AddCar(car2);
            _carRepo.AddCar(car3);
        }
    }
}
