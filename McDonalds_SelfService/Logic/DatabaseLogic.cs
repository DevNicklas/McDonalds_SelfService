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
        /// <summary>
        /// Gets all burgers
        /// </summary>
        /// <returns>A 2-dimensional string array with all burgers</returns>
        public string[,] GetBurgers()
        {
            Database db = new Database();
            return db.GetProducts("Burgers");
        }

        /// <summary>
        /// Gets all sides and dips
        /// </summary>
        /// <returns>A 2-dimensional string array with all sides and dips</returns>
        public string[,] GetSides()
        {
            Database db = new Database();
            return db.GetProducts("Sides");
        }

        /// <summary>
        /// Gets all cold drinks
        /// </summary>
        /// <returns>A 2-dimensional string array with all cold drinks</returns>
        public string[,] GetDrinks()
        {
            Database db = new Database();
            return db.GetProducts("Drinks");
        }

        /// <summary>
        /// Gets name of a burger
        /// </summary>
        /// <param name="productNum">product number of the burger</param>
        /// <returns>A string which is the name of the burger</returns>
        public string GetBurgerName(byte productNum)
        {
            Database db = new Database();
            return db.GetProductName("Burgers", productNum);
        }

        /// <summary>
        /// Gets all burger ingredients
        /// </summary>
        /// <param name="productName">name of product</param>
        /// <returns>A array with product ingredients</returns>
        public string[] GetBurgerIngredients(string productName)
        {
            Database db = new Database();
            return db.GetProductIngredients("Burgers", productName);
        }
    }
}
