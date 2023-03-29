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

        public static void WriteAt(string s, int x, int y)
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

            int width = 30;
            int height = 32;

            Console.SetWindowSize(width, height);

            for (int i = 0; i < height; i += 2)
            {
                WriteAt("||        |        |        ||", 0, i);
                WriteAt("||                          ||", 0, i + 1);
            }

            WriteAt("||        |        |        ||", 0, 0);
            WriteAt("||                          ||", 0, 1);
            WriteAt("||        |        |        ||", 0, 2);
            WriteAt("||                          ||", 0, 3);

            Car player = new Car(1, 0);

            Obstacle temp = new Obstacle(1, 11);
            Obstacle temp2 = new Obstacle(2, 11);
            Obstacle temp3 = new Obstacle(3, 11);

            /*
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
