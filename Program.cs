using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Program
    {
        protected static int origRow;
        protected static int origCol;

        protected static void WriteAt(string s, int x, int y)
        {
            try
            {
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e)
            {
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }
        
        static void Main(string[] args)
        {
            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;

            WriteAt("||        |        |        ||", 0, 0);
            WriteAt("||                          ||", 0, 1);
            WriteAt("||        |        |        ||", 0, 2);
            WriteAt("||                          ||", 0, 3);

            WriteAt("[¨¨¨¨]", 3, 0);
            WriteAt("|›__‹|", 3, 1);
            WriteAt("||__||", 3, 2);
            WriteAt("[____]", 3, 3);

            /*
            [¨¨¨¨]
            |╲__╱|
            ||__||
            [____]
            
            int width = 16;
            int height = 16;
            int what = 5;

            //Console.SetWindowSize(width, height);
            
            Console.WriteLine("■ ■ ■ ■");
            Console.WriteLine("■ ■ ■ ■");
            Console.WriteLine("■ ■ ■ ■");
            
            for (int i = 0; i < what; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("a");

                Console.ReadLine();
            }
            */
            Console.ReadLine();
        }
    }
}
