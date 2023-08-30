using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Gui
{
    internal class DrawBox : Screenmanager
    {
        private int x;
        private int y;
        private int height;
        private int width;
        private string[,] textArr;
        private ConsoleColor boxColor;
        private ConsoleColor textColor;

        /// <summary>
        /// Initializes a new instance of the <see cref="DrawBox"/> class
        /// </summary>
        /// <param name="x">start x position</param>
        /// <param name="y">start y position</param>
        /// <param name="height">height of box</param>
        /// <param name="width">width of box</param>
        /// <param name="textArr">text to write</param>
        /// <param name="boxColor">color of box</param>
        /// <param name="textColor">color of text</param>
        public DrawBox(int x, int y, int height, int width, string[,] textArr, ConsoleColor boxColor, ConsoleColor textColor)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
            this.textArr = textArr;
            this.boxColor = boxColor;
            this.textColor = textColor;
        }

        /// <summary>
        /// Uses the fields and draws an box within them
        /// </summary>
        public void Draw()
        {
            // Color of foreground before changing it
            ConsoleColor previousColor = Console.ForegroundColor;

            Console.ForegroundColor = boxColor;
            // Top horizontal line
            DrawHorizontalLine(x, y, width, '═', '╔', '╗');

            // Lower horizontal line
            // The y value has been subtracted with one, since the top horizontal line is printed, and counts as one
            DrawHorizontalLine(x, y + height - 1, width, '═', '╚', '╝');

            // Both vertical lines
            // If i = 0 then its the vertical line to the left
            // If i = 1 then its the vertical line to the right
            //
            // The x value is calculated by using the index of the loop and
            // multiplying it with the width-1, since the first value of x is 0 and not 1.
            // Then it takes that result and adds to the x value
            //
            // The y value has been added by one, since the vertical line is printed just under the top horizontal line
            //
            // The height or length of the line, is subtracted with two, since the line has to be printed between
            // the top and bottom horizontal lines
            for (int i = 0; i < 2; i++)
            {
                DrawVerticalLine(x + i * (width - 1), y + 1, height - 2, '║');
            }

            // Change the color back to the previousColor
            Console.ForegroundColor = previousColor;

            if (textArr != null)
            {
                // Change color
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
