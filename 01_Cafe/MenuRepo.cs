using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_Cafe
{
    public class MenuRepo : MenuItemRepo
    {
        public List<MenuItem> GetAllMenuItems()
        {
            List<MenuItem> allMenuItems = new List<MenuItem>();
            foreach (MenuItem menuItem in _menu)
            {
                if (menuItem is MenuItem)
                {
                    allMenuItems.Add((MenuItem)menuItem);
                }
            }
            return allMenuItems;
        }


    }
}
