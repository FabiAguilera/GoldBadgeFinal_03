using KomodoCafeRepo;
using KomodoCafeRepository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KomodoCafeUI
{
    public class ProgramUI
    {
        private MenuRepo _menuRepo = new MenuRepo();

        private void SeedData()
        {
            Menu menuItemToBeAdded = new Menu(1, "Burger n Fries", "steak burger garnished with caramelized onions", "steak burger, potatoe", 12);

            _menuRepo.CreateMealNum(menuItemToBeAdded);
        }

        public void Run()
        {
            RunApplication();
        }

        public void MenuEntry()
        {
            Console.WriteLine("Welcome to the Komodo Cafe Menu Portal! Here, you may create new menu items, delete menu items, and receive a list of\n" +
                "all items on the cafe's menu. Choose from the following options:\n" +
                "**********************************************************************************************\n" +
                "" +
                "1. Create a menu item\n" +
                "2. View all menu items\n" +
                "3. View single menu item\n" +
                "4. Delete menu items\n" +
                "5. End application");
        }

        public void RunApplication()
        {
            SeedData();
            bool isRunning = true;
            while (isRunning)
            {

                Console.Clear();
                MenuEntry();
                string userInput = Console.ReadLine();
                switch (userInput)
                {
                    case "1":
                        CreateMenuItem();
                        break;
                    case "2":
                        ViewAllMenuItem();
                        break;
                    case "3":
                        ViewSingleMenuItem();
                        break;
                    case "4":
                        DeleteMenuItem();
                        break;                    
                    case "5":
                        isRunning = false;
                        break;
                    default:
                        break;
                }
            }
        }

        public void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter which menu number to delete: ");
            int mealNum = Convert.ToInt32(Console.ReadLine());
            _menuRepo.DeleteMenuItem(mealNum);
            Console.WriteLine("Menu item has now been deleted!");
            Console.ReadKey();
            
        }

        private void ViewAllMenuItem()
        {
            Console.Clear();

            List<Menu> listOfMenuItems = _menuRepo.GetMenuItems();

            foreach (var menu in listOfMenuItems)
            {
                DisplayMenuInfo(menu);
            }
            Console.ReadLine();

        }

        public void DisplayMenuInfo(Menu menu)
        {
            Console.WriteLine($"{menu.MealNum}\n" +
                $"{menu.MealName}\n" +
                $"{menu.MealDescription}\n" +
                $"{menu.IngredientList}\n" +
                $"{menu.MealPrice}");
            Console.WriteLine("****************************************");
            
        }

        public void ViewSingleMenuItem()
        {
            Console.Clear();

            Console.WriteLine("Please enter the meal number you wish to view: ");

            int mealNum = Convert.ToInt32(Console.ReadLine());

            Menu entree = _menuRepo.GetMenuByNum(mealNum);
            DisplayMenuInfo(entree);
            Console.ReadLine();

        }

        public void CreateMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Please enter a meal number: ");
            int userInputMenuNumber;
         
            while (!int.TryParse(Console.ReadLine(), out
                userInputMenuNumber))
            {
                Console.WriteLine("Please enter a valid menu number: ");
            }
            
            Console.WriteLine("Please enter name of the meal: ");
            string userInputMenuName = Console.ReadLine();


            Console.WriteLine("Please enter a description of the meal: ");
            string userInputMenuDescription = Console.ReadLine();


            Console.WriteLine("Please enter list of ingredients: ");
            string userInputMenuIngredients = Console.ReadLine();


            Console.WriteLine("Please enter price of meal: ");
            decimal userInputMenuPrice = Convert.ToDecimal(Console.ReadLine());


            Menu menuItemToBeAdded = new Menu(userInputMenuNumber, userInputMenuName, userInputMenuDescription, userInputMenuIngredients, userInputMenuPrice);

            bool isSuccessfull = _menuRepo.CreateMealNum(menuItemToBeAdded);

            if (isSuccessfull)
            {
                Console.WriteLine($"{userInputMenuName} was successfully added!");
            }
            else
            {
                Console.WriteLine($"{userInputMenuName} was not added to the database! Please enter correct information: ");
            }
            Console.ReadLine();

     

        }


    }
}