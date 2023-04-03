using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

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
            int height = 36;

            Console.SetWindowSize(width, height);

            Road road = new Road(1, height);

            Car player = new Car(1, 0);

            Obstacle[] temp = { new Obstacle(1, 4), new Obstacle(1, 8), new Obstacle(1, 12), new Obstacle(1, 16), new Obstacle(1, 20), new Obstacle(1, 24), new Obstacle(1, 28) };

            Console.ReadLine();
        }
    }
}
