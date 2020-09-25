using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo : MenuItem
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
        public MenuItem GetMenuItemByNumber(string number)
        {
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem.Number.ToLower() == number.ToLower())
                {
                    return menuItem;
                }
            }
            return null;
        }
    }
}
