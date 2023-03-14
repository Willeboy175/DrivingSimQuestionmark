using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
            Console.SetWindowSize(30, 40);

            Console.WriteLine("||        |        |        ||");
            Console.WriteLine("||                          ||");
            Console.WriteLine("||                          ||");
            Console.WriteLine("||        |        |        ||");
            Console.WriteLine("||                          ||");
            Console.WriteLine("||                          ||");


            [¨¨¨¨]
            |╲__╱|
            ||__||
            [____]
            */


            int width = 16;
            int height = 16;
            int what = 5;

            Console.SetWindowSize(width, height);
            /*
            Console.WriteLine("■ ■ ■ ■");
            Console.WriteLine("■ ■ ■ ■");
            Console.WriteLine("■ ■ ■ ■");
            */
            for (int i = 0; i < what; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("a");

                Console.ReadLine();
            }

            Console.ReadLine();
        }
    }
}
