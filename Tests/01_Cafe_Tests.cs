using _01_Cafe_Console.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void AddMenuItem_ShouldReturnTrue()
        {
            Menu item = new Menu();
            MenuRepo repository = new MenuRepo();
            bool addResult = repository.AddMenuToDirectory(item);
            Assert.IsTrue(addResult);
        }
        [TestMethod]
        public void ShowAllMenuItems_ShouldCorrectCollection()
        {
            Menu item = new Menu();
            MenuRepo repository = new MenuRepo();
            repository.AddMenuToDirectory(item);
            List<Menu> items = repository.GetMenu();
            bool hasItems = items.Contains(item);
            Assert.IsTrue(hasItems);
        }
        private MenuRepo _repo;
        [TestInitialize]
        public void Arrange()
        {
            _repo = new MenuRepo();
            Menu item1 = new Menu(1, "Hamburger", "Yummy!", "Tomatoes, Onions, Beef, Wheat", 4.35m);
            _repo.AddMenuToDirectory(item1);
        }
        [TestMethod]
        public void DeleteMenu_ShouldReturnTrue()
        {
            Menu menu = _repo.GetMenuByNumber(1);
            bool deleteMenu = _repo.DeleteExistingMenu(menu);
            Assert.IsTrue(deleteMenu);
        }
    }
}
