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
        /// <summary>
        /// Draws the Self-service menu
        /// </summary>
        public void Draw()
        {
            // Draws outline for category menu (left menu)
            DrawBox(0, 0, 39, 20, Console.ForegroundColor);
            
            // Draws outline for product menu (right menu)
            DrawBox(21, 0, 39, 148, Console.ForegroundColor);

            // Draws a text, and colors it orange to indicate which category your are on
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            DrawText(2, 1, "BURGERS");
            Console.ResetColor();

            // Category text
            string[,] textArr = new string[,]
            {
                // X    Y      Text
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
                // The correct values ​​are found through the 2-dimensional array.
                // Since the column values ​​will always be the same, we just loop through the rows
                // in our 2-dimensional array
                DrawText(Convert.ToInt32(textArr[i, 0]), Convert.ToInt32(textArr[i, 1]), textArr[i, 2]);
            }

            // Allows the user to select a category they want to be under
            GetUserCategoryChoice();
        }

        #region Input from user
        /// <summary>
        /// The user chooses between the categories
        /// </summary>
        private void GetUserCategoryChoice()
        {
            const byte LOWEST_CHOICE_NUM = 1;
            const byte CATEGORY_AMOUNT = 3;

            // Category which the user is currently on
            byte currentCategoryNumber = 1;

            bool isCategoryChosen = false;

            ConsoleKey key;

            // Loops until the user has chosen a category
            while(!isCategoryChosen)
            {
                key = Console.ReadKey(true).Key;
                switch(key)
                {

                    // When the user presses the up arrow key then if the category number is larger
                    // than the lowest number possible, then 1 must be subtracted
                    case ConsoleKey.UpArrow:
                        if (currentCategoryNumber > LOWEST_CHOICE_NUM)
                        {
                            currentCategoryNumber--;
                        }
                        break;

                    // When the user presses the down arrow key then if the category number is less
                    // than the number of categories, then 1 must be added
                    case ConsoleKey.DownArrow:
                        if (currentCategoryNumber < CATEGORY_AMOUNT)
                        {
                            currentCategoryNumber++;
                        }
                        break;

                    // When the user presses enter, the user selects the category colored orange/dark yellow
                    case ConsoleKey.Enter:
                        isCategoryChosen = true;
                        break;

                }

                // Colors the category the user is on in orange, and the rest is colored the standard color
                ChooseCategory(currentCategoryNumber);
            }

            // When a category is chosen, the 3 categories is colored the standard color
            Console.ResetColor();
            DrawText(2, 6, "SIDES & DIPS");
            DrawText(2, 11, "COLD DRINKS");
            DrawText(2, 1, "BURGERS");

            // Draws all products within its category
            DrawProducts(currentCategoryNumber);

            // Allows the user to select a product they want to add to their order
            GetUserProductChoice();
        }

        /// <summary>
        /// The user chooses between the products
        /// </summary>
        private void GetUserProductChoice()
        {
            const byte LOWEST_CHOICE_NUM = 1;
            const byte PRODUCT_AMOUNT = 5;

            // Product which the user is currently on
            byte currentProductNumber = 1;

            bool isProductChosen = false;

            ConsoleKey key;

            // Loops until the user has chosen a product
            while (!isProductChosen)
            {
                // Colors the first product orange
                ChooseProduct(currentProductNumber);

                key = Console.ReadKey(true).Key;
                switch(key)
                {
                    // When the user presses the left arrow key down, then 1 must be subtracted from the
                    // current product number, but only if the product number is higher than the lowest number
                    case ConsoleKey.LeftArrow:
                        if(currentProductNumber > LOWEST_CHOICE_NUM)
                        {
                            currentProductNumber--;
                        }
                        break;
                    // When the user presses the right arrow key down, 1 must be added to the current product number
                    // but only if the product number is below the highest number possible
                    case ConsoleKey.RightArrow:
                        if (currentProductNumber < PRODUCT_AMOUNT)
                        {
                            currentProductNumber++;
                        }
                        break;
                    // When the user presses enter, the user selects the product colored orange
                    case ConsoleKey.Enter:
                        isProductChosen = true;
                        break;
                }
            }

            // When a product is chosen, a pop up screen will appear at is position
            PopUpScreen popUp = new PopUpScreen();
            popUp.DrawPopUp(currentProductNumber);
        }
        #endregion

        /// <summary>
        /// Selects a category and colors it orange
        /// </summary>
        /// <param name="currentCategoryNumber">current category number which the user is on</param>
        private void ChooseCategory(byte currentCategoryNumber)
        {
            switch (currentCategoryNumber)
            {
                // Chooses category burgers
                case 1:
                    DrawText(2, 6, "SIDES & DIPS");
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 1, "BURGERS");
                    Console.ResetColor();
                    break;
                // Chooses category sides and dips
                case 2:
                    DrawText(2, 1, "BURGERS");
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 6, "SIDES & DIPS");
                    Console.ResetColor();
                    break;
                // Chooses category cold drinks
                case 3:
                    DrawText(2, 1, "BURGERS");
                    DrawText(2, 6, "SIDES & DIPS");
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    DrawText(2, 11, "COLD DRINKS");
                    Console.ResetColor();
                    break;
            }
        }

        /// <summary>
        /// Selects a product and colors it orange
        /// </summary>
        /// <param name="currentProductNumber"></param>
        private void ChooseProduct(byte currentProductNumber)
        {
            const int PRODUCT_AMOUNT = 5;

            const int POSITION_X = 23;
            const int POSITION_Y = 1;
            const int HEIGHT = 6;
            const int WIDTH = 28;

            // Draws every single product, but in difference colors
            for (int i = 0; i < PRODUCT_AMOUNT; i++)
            {
                // Draws the choosed product
                if(i == currentProductNumber - 1)
                {
                    // Position x is calculated by multiplying the width of the product box by the loop index
                    // and then add it to the start position of the first product box
                    DrawBox(POSITION_X + (WIDTH+1) * i, POSITION_Y, HEIGHT, WIDTH, ConsoleColor.DarkYellow);
                    continue;
                }

                // Draws all the products which aren't choosed
                DrawBox(POSITION_X + (WIDTH+1) * i, POSITION_Y, HEIGHT, WIDTH, Console.ForegroundColor);
            }
        }

        /// <summary>
        /// Draws every product in a certain category, which are in the database
        /// </summary>
        /// <param name="categoryNum">category which contains the products</param>
        private void DrawProducts(byte categoryNum)
        {
            DatabaseLogic dbLogic = new DatabaseLogic();
            string[,] data;

            // Retrieves the correct data, and puts the data
            // in the 2-dimensional string array
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

            const int POSITION_X = 23;
            const int POSITION_Y = 1;
            const int HEIGHT = 6;
            const int WIDTH = 28;

            // Draws every single product box, and the text
            ProductManager productManager = new ProductManager(POSITION_X, POSITION_Y, HEIGHT, WIDTH, Console.ForegroundColor, data[0,0], data[0,1]);
            for(int i = 0; i < data.GetLength(0); i++) 
            {
                // Updates the fields, and draws the product in the correct position
                productManager.ProductName = data[i, 0];
                productManager.ProductPrice = data[i, 1];
                productManager.DrawProduct();

                // To be able to draw all the boxes in the right places
                // and have a single char space between each box then I have to remove one from
                // the length of the box, and add that result to the x position from the previous box
                productManager.X = productManager.X + (WIDTH-1);
            }
        }
    }
}
