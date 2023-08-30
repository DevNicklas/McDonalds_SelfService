using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService.Gui
{
    abstract internal class Screenmanager
    {
        /// <summary>
        /// Draws a horizontal line within some criterias
        /// </summary>
        /// <param name="x">start position of x</param>
        /// <param name="y">start position of y</param>
        /// <param name="length">length of the line</param>
        /// <param name="horizontalChar">horizontal line character</param>
        /// <param name="leftCornerChar">left corner character</param>
        /// <param name="rightCornerChar">right corner character</param>
        protected void DrawHorizontalLine(int x, int y, int length, char horizontalChar, char leftCornerChar, char rightCornerChar)
        {
            Console.SetCursorPosition(x, y);

            // Prints one left corner, a horizontal line with a certain length, and a right corner
            // 2 is removed from the length for printing the right size, since the 2 corners adds 2 in length
            Console.Write(leftCornerChar + new string(horizontalChar, length - 2) + rightCornerChar);
        }

        /// <summary>
        /// Draws a vertical line within some criterias
        /// </summary>
        /// <param name="x">start position of x</param>
        /// <param name="y">start position of y</param>
        /// <param name="height">height of the line</param>
        /// <param name="verticalChar">vertical line character</param>
        protected void DrawVerticalLine(int x, int y, int length, char verticalChar)
        {
            // Prints every single vertical char which needed, so it forms
            // the vertical line which is asked for
            for (int i = 0; i < length; i++)
            {
                Console.SetCursorPosition(x, y + i);
                Console.Write(verticalChar);
            }
        }

        /// <summary>
        /// Draws a text within some criterias
        /// </summary>
        /// <param name="x">start position of x</param>
        /// <param name="y">start position of y</param>
        /// <param name="text">text to print</param>
        protected void DrawText(int x, int y, string text)
        {
            Console.SetCursorPosition(x, y);
            Console.Write(text);
        }

        /// <summary>
        /// Uses the fields and draws an box within them
        /// </summary>
        protected void DrawBox(int x, int y, int height, int width, ConsoleColor boxColor)
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
        }
    }
}
