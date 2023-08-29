using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.View
{
    internal class DrawBox : Screenmanager
    {
        int x;
        int y;
        int height;
        int width;
        string[,] textArr;
        ConsoleColor textColor;
        ConsoleColor boxColor;

        public DrawBox(int x, int y, int height, int width, string[,] textArr, ConsoleColor textColor, ConsoleColor boxColor)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.textArr = textArr;
            this.textColor = textColor;
            this.boxColor = boxColor;
        }

        public void Draw()
        {
            // Top horizontal line
            DrawHorizontalLine(x, y, width, '═', '╔', '╗');
            // Lower horizontal line
            DrawHorizontalLine(x, y + height, width, '═', '╚', '╝');

            // Both vertical lines
            // If i = 0 then its the vertical line to the left
            // If i = 1 then its the vertical line to the right
            //
            // The x value is calculated by using the index of the loop and
            // multiplying it with the width-1, since the first value of x is 0 and not 1.
            // Then it takes that result and adds to the x value
            //
            // The y value has been added by one, since the vertical line is printed just under the top horizontal line
            for (int i = 0; i < 2; i++)
            {
                DrawVerticalLine(x + i * (width - 1), y + 1, height - 1, '║');
            }
            if (textArr != null)
            {
                // Color of foreground before changing it
                ConsoleColor previousColor = Console.ForegroundColor;

                Console.ForegroundColor = textColor;

                // Draws every single text, which is added to the 2-dimensional array textArr
                for (int i = 0; i < textArr.GetLength(0); i++)
                {
                    DrawText(Convert.ToInt32(textArr[i, 0]), Convert.ToInt32(textArr[i, 1]), textArr[i, 2]);
                }

                // Change the color back to the previousColor
                Console.ForegroundColor = previousColor;
            }
        }
    }
}
