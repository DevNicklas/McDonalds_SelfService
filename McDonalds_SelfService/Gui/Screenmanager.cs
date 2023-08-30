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
    }
}
