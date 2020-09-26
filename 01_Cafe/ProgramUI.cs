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
        private readonly MenuItemRepo _menuRepo = new MenuItemRepo();
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
                        CreateItem();
                        break;
                    case "3":
                        DeleteItem();
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
                    $"Description: {menuItem.Description} \n" +
                    $"Ingredients: {menuItem.Ingredients} \n" +
                    $"Price: ${menuItem.Price} \n" +
                    "-------------------------");
            }
        }

        private void CreateItem()
        {
            Console.Clear();
            MenuItem menuItem = new MenuItem();
            Console.WriteLine("Enter the Item Number");
            menuItem.Number = Console.ReadLine();
            Console.WriteLine("Enter the Item Name");
            menuItem.Name = Console.ReadLine();
            Console.WriteLine("Enter a Description of the Item");
            menuItem.Description = Console.ReadLine();
            Console.WriteLine("Enter the Item Ingredients");
            menuItem.Ingredients = Console.ReadLine();
            Console.WriteLine("Enter Price amount");
            menuItem.Price = Convert.ToDecimal(Console.ReadLine());

            _menuRepo.AddItemToMenu(menuItem);
        }

        private void DeleteItem()
        {
            Console.WriteLine("Which item do you want to delete?");
            List<MenuItem> menuItems = _menuRepo.GetMenuItems();
            int count = 0;
            foreach (var menuItem in menuItems)
            {
                count++;
                Console.WriteLine($"{count}: {menuItem.Name}");
            }
            int userInput = Convert.ToInt32(Console.ReadLine());
            int indexValue = userInput - 1;
            if (indexValue >= 0 && indexValue < menuItems.Count)
            {
                MenuItem itemSelected = menuItems[indexValue];
                if (_menuRepo.DeleteMenuItem(itemSelected))
                {
                    Console.WriteLine($"{itemSelected.Name} removed.");
                }
                else
                {
                    Console.WriteLine("Invald");
                }
            }
            else
            {
                Console.WriteLine("Invald");
            }
            Console.WriteLine("Press any key to continue.........");
            Console.ReadKey();
        }

        private void SeedData()
        {
            var menuItemOne = new MenuItem("1", "Buger", "Buns and beef", "Angus Beef", 6.25m);
            var menuItemTwo = new MenuItem("2", "Hot Dog", "Dog in a bun", "Ballpark Frank", 4.50m);
            _menuRepo.AddItemToMenu(menuItemOne);
            _menuRepo.AddItemToMenu(menuItemTwo);
        }
    }
}
