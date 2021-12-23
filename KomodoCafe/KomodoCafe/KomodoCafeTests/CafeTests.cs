using KomodoCafeRepo;
using KomodoCafeRepository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace KomodoCafeTests
{
    [TestClass]
    public class CafeTests
    {
        MenuRepo _menuRepo = new MenuRepo();
        Menu _menu = new Menu();
        List<Menu> _menuItems = new List<Menu>();

        private void SeedTest()
        {
            Menu _menuOne = new Menu(1, "a", "a", "a", 10);
            Menu _menuTwo = new Menu(2, "b", "b", "b", 11);
            Menu _menuThree = new Menu(3, "c", "c", "c", 12);
            Menu _menuFour = new Menu(4, "d", "d", "d", 13);
            Menu _menuFive = new Menu(5, "e", "e", "e", 14);
            _menuItems.Add(_menuOne);
            _menuItems.Add(_menuTwo);
            _menuItems.Add(_menuThree);
            _menuItems.Add(_menuFour);
            _menuItems.Add(_menuFive);
        }

        [TestMethod]
        public void CreateMealNum_ValidMealNum_ReturnsTrue()
        {
            //Arrange
            _menu.MealNum = 0;
            _menu.MealName = "burger";
            _menu.MealDescription = "asdfasg";
            _menu.IngredientList = "jnfon";
            _menu.MealPrice = 12;

            //Act
            bool mealNumCreated = _menuRepo.CreateMealNum(_menu);

            //Assert
            Assert.IsTrue(mealNumCreated);

        }

        [TestMethod]
        public void GetMenuItems_ValidInfo_ReturnsEqual()
        {
            //Arrange
            Menu _menuOne = new Menu(1, "a", "a", "a", 10);
            _menuRepo.CreateMealNum(_menuOne);
            //Act
            _menuRepo.GetMenuItems();

            //Assert
            Assert.AreEqual(1, _menuRepo.GetMenuItems().Count);

        }

        [TestMethod]
        public void GetMenuByNum_ValidInfo_ReturnsEqual()
        {
            //Arrange
            SeedTest();
            //Act
            _menuRepo.GetMenuByNum(5);
            //Assert
            Assert.AreEqual(14, _menuItems[4].MealPrice);
            _menuItems.Clear();
        }

        [TestMethod]
        public void DeleteMenuItem_ValidInfo_ReturnsTrue()
        {
            //Arrange
            Menu _menuOne = new Menu(3, "a", "a", "a", 10);
            _menuRepo.CreateMealNum(_menuOne);
            //Act
            bool mealNumDelete = _menuRepo.DeleteMenuItem(3);

            //Assert
            Assert.IsTrue(mealNumDelete);
        }
    }
}
