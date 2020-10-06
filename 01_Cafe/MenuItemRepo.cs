using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuItemRepo : MenuItem
    {
        protected readonly List<MenuItem> _menu = new List<MenuItem>();

        public bool AddItemToMenu(MenuItem item)
        {
            int startingCount = _menu.Count;
            _menu.Add(item);
            bool wasAdded = (_menu.Count > startingCount) ? true : false;
            return wasAdded;
        }

        public List<MenuItem> GetMenuItems()
        {
            return _menu;
        }

        public bool DeleteMenuItem(MenuItem menuItem)
        {
            bool deleteResult = _menu.Remove(menuItem);
            return deleteResult;
        }
    }
}
