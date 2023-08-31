using McDonalds_SelfService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Gui
{
    internal class PopUpScreen : Screenmanager
    {
        private int _height = 37;
        private int _width = 28;
        private int _x = 23;
        private int _y = 0;

        public void DrawPopUp(byte choiceProductNum)
        {
            _x = _x + ((choiceProductNum - 1) * 29);
            // Creates orange outline of box
            DrawBox(_x, _y+1, _height, _width, ConsoleColor.DarkYellow);
            
            // Clears everything else than product name and price within the outline
            for(int i = 1; i <= _height-5; i++)
            {
                DrawText(_x+1, _y+4+i, new string(' ', _width-2));
            }

            DatabaseLogic dbLogic = new DatabaseLogic();
            string productName = dbLogic.GetBurgerName(choiceProductNum);

            string[] ingredients = dbLogic.GetBurgerIngredients(productName);
            DrawText(_x + 2, _y +6, "Ingredienser:");
            for(int i = 0; i < ingredients.Length; i++)
            {
                DrawText(_x + 2, _y + 8 + i, ingredients[i]);
            }
            Console.ReadLine();
        }
    }
}
