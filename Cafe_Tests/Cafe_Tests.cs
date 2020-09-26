using System;
using System.Collections.Generic;
using _01_Cafe;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Cafe_Tests
{
    [TestClass]
    public class Cafe_Tests
    {
        [TestMethod]
        public void AddItemToMenuAddsItem()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            bool result = repo.AddItemToMenu(item);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetMenuItemsShouldGetItems()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddItemToMenu(item);
            List<MenuItem> listOfItems = repo.GetMenuItems();
            bool menuHasItems = listOfItems.Contains(item);
            Assert.IsTrue(menuHasItems);
        }

        [TestMethod]
        public void DeleteItemsRemovesItems()
        {
            MenuItem item = new MenuItem();
            MenuItemRepo repo = new MenuItemRepo();
            repo.AddItemToMenu(item);
            bool delete = repo.DeleteMenuItem(item);
            Assert.IsTrue(delete);
        }
    }
}
