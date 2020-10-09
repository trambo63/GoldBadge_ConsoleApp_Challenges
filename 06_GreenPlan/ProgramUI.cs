using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06_GreenPlan
{
    public class ProgramUI
    {
        public void Run()
        {
            //SeedData();
            RunMenu();
        }

        private void RunMenu()
        {
            bool keepThinking = true;
            while (keepThinking)
            {
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
                        //ShowAllCars();
                        break;
                    case "2":
                        //AddCar();
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
    }
}
