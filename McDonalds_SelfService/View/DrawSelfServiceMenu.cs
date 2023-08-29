using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.View
{
    internal class DrawSelfServiceMenu
    {
        public void DrawTest()
        {
            string[,] text = new string[,]
            {
                { "2", "1", "BURGERS" },
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
            DrawBox categoryBox = new DrawBox(0, 0, 38, 20, text, Console.ForegroundColor, Console.ForegroundColor);
            DrawBox productBox = new DrawBox(21, 0, 38, 149, text, Console.ForegroundColor, Console.ForegroundColor);

            categoryBox.Draw();
            productBox.Draw();
        }
    }
}
