using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class ProgramUI
    {
        public void Run()
        {
            SeedData();
            RunMenu();
        }

        public List<MenuItem> menuList = new List<MenuItem>();
        private void RunMenu()
        {
            //MenuItem newItem = new MenuItem("1", "Buger", "Buns and beef", "Angus Beef", 10.24m);
            bool keepThinking = true;
            while (keepThinking)
            {
                Console.Clear();
                Console.WriteLine("Type a number from the menu and press enter: \n" +
                    "1) Show all Menu Items \n" +
                    "2) Create Menu Item \n" +
                    "3) Delete a Menu Item \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        //ShowAllItems();
                        Console.Clear();
                        Console.WriteLine();
                        Console.ReadKey();
                        break;
                    case "2":
                        //CreateItem();
                        break;
                    case "3":
                        //DeleteItem();
                        break;
                    case "4":
                        keepThinking = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Entry! Press Enter and try agian");
                        Console.ReadKey();
                        break;
                }
            }
        }

        public void SeedData()
        {
            var menuItemOne = new MenuItem("1", "Buger", "Buns and beef", "Angus Beef", 10.24m);
            menuList.Add(menuItemOne);
        }
    }
}
