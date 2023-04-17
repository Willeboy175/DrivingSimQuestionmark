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
            int width = 32;
            int height = 45;
            bool gameOver = false;
            int road = 1;
            int playerX = 2;
            int playerY = 9;
            int[] obstaclesX;
            int[] obstaclesY;
            Obstacle[] obstacles;
            ConsoleKeyInfo playerInput;

            Console.Clear();
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            Console.SetWindowSize(width, height);

            WriteAt("  ============================  ", 0, 1);
            WriteAt("    --Press A to move left--    ", 0, 2);
            WriteAt("    --Press D to move right--   ", 0, 3);
            WriteAt("   --Press W to move nothing--  ", 0, 4);
            WriteAt("  ============================  ", 0, 5);
            WriteAt("                                ", 0, 6);
            WriteAt("                                ", 0, 7);
            WriteAt("  ============================  ", 0, 8);
            WriteAt("    --To start, press ENTER--   ", 0, 9);
            WriteAt("  ============================  ", 0, 10);
            Console.ReadLine();

            while (gameOver == false)
            {
                for (int i = 0; i < 4; i++)
                {
                    Road background = new Road(road, height);
                    road += 1;

                    if (road > 3)
                    {
                        road = 1;
                    }

                    Car player = new Car(playerX, playerY);

                    Thread.Sleep(100);
                }

                playerInput = Console.ReadKey(true);

                if (playerInput.Key == ConsoleKey.A)
                {
                    playerX -= 1;
                    if (playerX < 1)
                    {
                        playerX = 1;
                    }
                }

                if (playerInput.Key == ConsoleKey.D)
                {
                    playerX += 1;
                    if (playerX > 3)
                    {
                        playerX = 3;
                    }
                }

                //playerX = int.Parse(Console.ReadLine());
                //Console.ReadKey();
            }
        }
    }
}
