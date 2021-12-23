using KomodoCafeRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepository
{
    public class MenuRepo
    {
        private readonly List<Menu> _menuItems = new List<Menu>();

        public bool CreateMealNum(Menu menu)
        {
            if (menu is null)
            {
                return false;
            }
            else
            {
                Console.WriteLine("You have now created a new meal!");
            }
            _menuItems.Add(menu);
            return true;
        }

        public List<Menu> GetMenuItems()
        {
            return _menuItems;
        }

       

        public Menu GetMenuByNum(int mealNum)
        {
            foreach (Menu menu in _menuItems)
            {
                if (mealNum == menu.MealNum)
                {
                    return menu;
                }
            }
            return null;


        }

        


        public bool DeleteMenuItem(int mealNum)
        {
            Menu menuItemsToBeRemoved = GetMenuByNum(mealNum);
            if (menuItemsToBeRemoved == null)
            {
                return false;
            }
            else
            {
                _menuItems.Remove(menuItemsToBeRemoved);
                return true;
            }
        }

    }
}
