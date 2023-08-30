using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace McDonalds_SelfService.Gui
{
    internal class DrawSelfServiceMenu : Screenmanager
    {
        public void Draw()
        {
            string[,] textArr = new string[,]
            {
                { "2", "1", "BURGERS" },
                { "3", "2", "> xxxxx" },
                { "3", "3", "> xxxxx" },
                { "3", "4", "> xxxxx" },
                { "2", "6", "SIDES & DIPS" },
                { "3", "7", "> xxxxx" },
                { "3", "8", "> xxxxx" },
                { "3", "9", "> xxxxx" },
                { "2", "11", "COLD DRINKS" },
                { "3", "12", "> xxxxx" },
                { "3", "13", "> xxxxx" },
                { "3", "14", "> xxxxx" }
            };
            DrawBox(0, 0, 39, 20, Console.ForegroundColor);
            DrawBox(21, 0, 39, 148, Console.ForegroundColor);

            // Draws every single text, which is added to the 2-dimensional array textArr
            for (int i = 0; i < textArr.GetLength(0); i++)
            {
                DrawText(Convert.ToInt32(textArr[i, 0]), Convert.ToInt32(textArr[i, 1]), textArr[i, 2]);
            }

            ProductManager productManager = new ProductManager(23, 1, 6, 28, Console.ForegroundColor);

            productManager.DrawBurgerProduct();

            GetUserChoice();
        }

        private void GetUserChoice()
        {
            byte choiceNumCategory = 1;
            byte choiceNumProduct = 1;
            ConsoleKey key;
            while (true)
            {
                key = Console.ReadKey(true).Key;
                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        if (choiceNumCategory > 1)
                        {
                            choiceNumCategory--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (choiceNumCategory < 3)
                        {
                            choiceNumCategory++;
                        }
                        break;
                    case ConsoleKey.LeftArrow:
                        if (choiceNumProduct > 1)
                        {
                            choiceNumProduct--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (choiceNumProduct < 5)
                        {
                            choiceNumProduct++;
                        }
                        break;
                }
            }
        }

        private void ChooseCategory(byte choiceNumCategory)
        {
            switch(choiceNumCategory)
            {
            }
        }

        private void ChooseProduct()
        {

        }
    }
}
