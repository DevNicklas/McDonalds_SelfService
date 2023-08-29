using McDonalds_SelfService.View;
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
            DrawSelfServiceMenu draw = new DrawSelfServiceMenu();
            draw.DrawTest();


            Console.ReadKey(true);
        }
    }
}
