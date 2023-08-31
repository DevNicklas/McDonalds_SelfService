using McDonalds_SelfService.Dal;
using McDonalds_SelfService.Gui;
using McDonalds_SelfService.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace McDonalds_SelfService
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(170, 40);

            // Draws the menu which the user can order products with
            DrawSelfServiceMenu draw = new DrawSelfServiceMenu();
            draw.Draw();

            Console.ReadKey(true);
        }
    }
}
