using McDonalds_SelfService.Logic;
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
            DrawBox(0, 0, 39, 20, Console.ForegroundColor);
            DrawBox(21, 0, 39, 148, Console.ForegroundColor);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawText(2, 1, "BURGERS");
            Console.ResetColor();

            string[,] textArr = new string[,]
            {
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

            // Draws every single text, which is added to the 2-dimensional array textArr
            for (int i = 0; i < textArr.GetLength(0); i++)
            {
                DrawText(Convert.ToInt32(textArr[i, 0]), Convert.ToInt32(textArr[i, 1]), textArr[i, 2]);
            }
            GetUserCategoryChoice();
        }

        private void GetUserCategoryChoice()
        {
            const byte LOWEST_CHOICE_NUM = 1;
            const byte CATEGORY_AMOUNT = 3;
            byte choiceNumCategory = 1;
            bool isCategoryChosen = false;
            ConsoleKey key;
            while(!isCategoryChosen)
            {
                key = Console.ReadKey(true).Key;
                switch(key)
                {
                    case ConsoleKey.UpArrow:
                        if(choiceNumCategory > LOWEST_CHOICE_NUM)
                        {
                            choiceNumCategory--;
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (choiceNumCategory < CATEGORY_AMOUNT)
                        {
                            choiceNumCategory++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        isCategoryChosen = true;
                        break;

                }
                ChooseCategory(choiceNumCategory);
            }
            Console.ResetColor();
            DrawText(2, 6, "SIDES & DIPS");
            DrawText(2, 11, "COLD DRINKS");
            DrawText(2, 1, "BURGERS");

            DrawProducts(choiceNumCategory);

            GetUserProductChoice();
        }

        private void GetUserProductChoice()
        {
            const byte LOWEST_CHOICE_NUM = 1;
            const byte PRODUCT_AMOUNT = 5;
            byte choiceNumProduct = 1;
            bool isProductChosen = false;
            ConsoleKey key;


            while(!isProductChosen)
            {
                ChooseProduct(choiceNumProduct);
                key = Console.ReadKey(true).Key;
                switch(key)
                {
                    case ConsoleKey.LeftArrow:
                        if(choiceNumProduct > LOWEST_CHOICE_NUM)
                        {
                            choiceNumProduct--;
                        }
                        break;
                    case ConsoleKey.RightArrow:
                        if (choiceNumProduct < PRODUCT_AMOUNT)
                        {
                            choiceNumProduct++;
                        }
                        break;
                    case ConsoleKey.Enter:
                        isProductChosen = true;
                        break;
                    case ConsoleKey.Escape:
                        return;
                }
            }
            PopUpScreen popUp = new PopUpScreen();
            popUp.DrawPopUp(choiceNumProduct);
        }

        private void ChooseCategory(byte choiceNumCategory)
        {
            switch (choiceNumCategory)
            {
                case 1:
                    DrawText(2, 6, "SIDES & DIPS");
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 1, "BURGERS");
                    Console.ResetColor();
                    break;
                case 2:
                    DrawText(2, 1, "BURGERS");
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 6, "SIDES & DIPS");
                    Console.ResetColor();
                    break;
                case 3:
                    DrawText(2, 1, "BURGERS");
                    DrawText(2, 6, "SIDES & DIPS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ResetColor();
                    break;
            }
        }

        private void ChooseProduct(byte choiceNumProduct)
        {
            for(int i = 0; i < 5; i++)
            {
                if(i == choiceNumProduct-1)
                {
                    DrawBox(23 + 29 * i, 1, 6, 28, ConsoleColor.DarkYellow);
                    continue;
                }
                DrawBox(23 + 29 * i, 1, 6, 28, Console.ForegroundColor);
            }
        }

        private void DrawProducts(byte categoryNum)
        {
            DatabaseLogic dbLogic = new DatabaseLogic();
            string[,] data;
            if(categoryNum == 1)
            {
                data = dbLogic.GetBurgers();
            }
            else if (categoryNum == 2)
            {
                data = dbLogic.GetSides();
            }
            else
            {
                data = dbLogic.GetDrinks();
            }

            ProductManager productManager = new ProductManager(23, 1, 6, 28, Console.ForegroundColor, data[0,0], data[0,1]);
            
            for(int i = 0; i < data.GetLength(0); i++) 
            {

                productManager.ProductName = data[i, 0];
                productManager.ProductPrice = data[i, 1];
                productManager.DrawProduct();
                productManager.X = productManager.X + 29;
            }
        }
    }
}
