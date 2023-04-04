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
            int width = 30;
            int height = 45;
            bool gameOver = false;
            int road = 2;
            int playerX = 2;
            int playerY = 9;

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            Console.SetWindowSize(width, height);

            while (gameOver == false)
            {
                Road background = new Road(road, height);

                Car player = new Car(playerX, playerY);

                Obstacle[] temp = { new Obstacle(1, 4), new Obstacle(1, 8), new Obstacle(1, 12), new Obstacle(1, 16), new Obstacle(1, 20), new Obstacle(1, 24), new Obstacle(1, 28) };
                
                Console.ReadLine();
            }
        }
    }
}
