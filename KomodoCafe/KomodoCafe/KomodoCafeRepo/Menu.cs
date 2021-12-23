using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafeRepo
{
    public class Menu
    {
        public Menu()
        {

        }


        public Menu(int mealNum, string mealName, string mealDescription, string ingredientList, decimal mealPrice)
        {
            MealNum = mealNum;
            MealName = mealName;
            MealDescription = mealDescription;
            IngredientList = ingredientList;
            MealPrice = mealPrice;
        }

        public int MealNum { get; set; }
        public string MealName { get; set; }
        public string MealDescription { get; set; }
        public string IngredientList { get; set; }
        public decimal MealPrice { get; set; }

        //public int SingleMenuItem(int menu)
        //{
        //    int output = Convert.ToInt32(String.Format("MealNum :{0} \n MealName :{1} \n MealDescription :{3} \n IngredientList :{4} \n MealPrice :{5}", this.MealNum, this.MealName, this.MealDescription, this.IngredientList, this.MealPrice));
        //    return output;

        //}
        //Console.WriteLine(String.Format("|{0, -35}|{1,-35}|{2,-35}|", "Developer ID", "Full Name", "Has PS Access?"));

    }
}
