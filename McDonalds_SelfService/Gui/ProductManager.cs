using McDonalds_SelfService.Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace McDonalds_SelfService.Gui
{
    internal class ProductManager : Screenmanager
    {
        private int x;
        private int y;
        private int height;
        private int width;
        private ConsoleColor boxColor;

        public ProductManager(int x, int y, int height, int width, ConsoleColor boxColor)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.boxColor = boxColor;
        }

        public void DrawBurgerProduct()
        {
            Database db = new Database();
            string[,] data = db.GetBurgers();

            for(int i = 0;  i < data.GetLength(0); i++)
            {
                DrawBox product = new DrawBox(x + 29 * i, y, height, width, null, boxColor, Console.ForegroundColor);
                DrawText((x + 2) + 29 * i , y + 2, "Produkt: " + data[i, 0]);
                DrawText((x + 2) + 29 * i, y + 3, "Pris: " + data[i, 1] + " kroner");
                product.Draw();
            }
        }
    }
}
