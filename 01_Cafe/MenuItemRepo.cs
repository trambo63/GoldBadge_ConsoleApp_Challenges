using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItemRepo : MenuItem
    {
        //this is the fake data base
        protected readonly List<MenuItem> _menu = new List<MenuItem>();

        //Crud
        //Create
        public bool AddItemToMenu(MenuItem item)
        {
            int startingCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        //Read
        public List<MenuItem> GetMenuItems()
        {
            return _menu;
        }

        //Read One 
        //public MenuItem GetMenuItemByNumber(string number)
        //{
        //    foreach (MenuItem menuItem in _menu)
        //    {
        //        if (menuItem.Number.ToLower() == number.ToLower())
        //        {
        //            return menuItem;
        //        }
        //    }
        //    return null;
        //}

        //Update
        //public bool UpdateMenuItem(string originalNumber, MenuItem newMenuItem)
        //{
        //    MenuItem oldItem = GetMenuItemByNumber(originalNumber);

        //    if (oldItem != null)
        //    {
        //        oldItem.Number = newMenuItem.Number;
        //        oldItem.Name = newMenuItem.Name;
        //        oldItem.Description = newMenuItem.Description;
        //        oldItem.Ingredients = newMenuItem.Ingredients;
        //        oldItem.Price = newMenuItem.Price;

        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //Delete
        public bool DeleteMenuItem(MenuItem menuItem)
        {
            bool deleteResult = _menu.Remove(menuItem);
            return deleteResult;
        }
    }
}
