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
        private readonly MenuRepo _menuRepo = new MenuRepo();
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
                    "1) Show all Menu Items \n" +
                    "2) Create Menu Item \n" +
                    "3) Delete a Menu Item \n" +
                    "4) Exit");
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        Console.Clear();
                        ShowAllItems();
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
        private void ShowAllItems()
        {
            Console.Clear();
            List<MenuItem> menuItemsList = _menuRepo.GetMenuItems();
            foreach (MenuItem menuItem in menuItemsList)
            {
                Console.WriteLine($"{menuItem.Number} {menuItem.Name} \n" +
                    $"{menuItem.Description} \n" +
                    $"{menuItem.Ingredients} \n" +
                    $"${menuItem.Price}");
            }
        }

        private void SeedData()
        {
            var menuItemOne = new MenuItem("1", "Buger", "Buns and beef", "Angus Beef", 10.24m);
            _menuRepo.AddItemToMenu(menuItemOne);
        }
    }
}
