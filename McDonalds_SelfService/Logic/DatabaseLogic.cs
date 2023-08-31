using McDonalds_SelfService.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Logic
{
    internal class DatabaseLogic
    {
        public string[,] GetBurgers()
        {
            Database db = new Database();
            return db.GetProducts("Burgers");
        }

        public string[,] GetSides()
        {
            Database db = new Database();
            return db.GetProducts("Sides");
        }

        public string[,] GetDrinks()
        {
            Database db = new Database();
            return db.GetProducts("Drinks");
        }

        public string GetBurgerName(byte productNum)
        {
            Database db = new Database();
            return db.GetProductName("Burgers", productNum);
        }

        public string[] GetBurgerIngredients(string productName)
        {
            Database db = new Database();
            return db.GetProductIngredients("Burgers", productName);
        }
    }
}
