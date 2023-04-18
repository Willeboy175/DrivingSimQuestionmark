using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DrivingSimQuestionmark
{
    internal class Program
    {
        //Offset för WriteAt funktionen till övre vänstra hörnet i konsollen
        protected static int origRow;
        protected static int origCol;

        public static void WriteAt(string s, int x, int y)
        {
            try //Försöker skriva på vald position
            {
                //Sätter pekarens position i x- och y-led beroende på funktionens offset
                //Skriver på pekarens position
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e) //Skapar ett felmeddelande ifall tidigare funktion misslyckas
            {
                //Rensar konsollen
                //Visar felmeddelandet
                Console.Clear();
                Console.WriteLine(e.Message);
            }
        }

        static void Main(string[] args)
        {
        Start:
            //Bredden på konsollen i kolumner
            //Höjden på konsollen i rader
            //Statement ifall spelet är över
            //Vilken cykel animationen för vägen är på
            int width = 32;
            int height = 45;
            bool gameOver = false;
            int road = 1;
            Random rnd = new Random();

            //Spelarens position i tilesystemet
            //Variabel för spelarens inputs
            int playerX = 2;
            int playerY = 9;
            ConsoleKeyInfo playerInput;

            //Bestämmer vilken variabel i obstacles, obstaclesX och obstaclesY som används för att spawna en ett nytt hinder
            //En variabel så att ett hinder bara spawnas varannan cykel
            //Array för hindernas position i x-led i tilesystemet
            //Array för hindernas position i y-led i rader
            int devi = 0;
            int cycle = 0;
            int[] obstaclesX = { 2, 2, 2, 2, 2, 2 };
            int[] obstaclesY = { 45, 45, 45, 45, 45, 45 };

            //Sätter offset för raderna i funktionen WriteAt
            //Sätter offset för kolumnerna i funktionen WriteAt
            //Sätter storleken för console fönstret
            origRow = Console.CursorTop;
            origCol = Console.CursorLeft;
            Console.SetWindowSize(width, height);


            Console.Clear();
            WriteAt("  ============================  ", 0, 1);
            WriteAt("    --Press A to move left--    ", 0, 2);
            WriteAt("    --Press D to move right--   ", 0, 3);
            WriteAt("   --Press W to move nothing--  ", 0, 4);
            WriteAt("   --Press ESC to main menu--   ", 0, 5);
            WriteAt("  ============================  ", 0, 6);
            WriteAt("                                ", 0, 7);
            WriteAt("                                ", 0, 8);
            WriteAt("  ============================  ", 0, 9);
            WriteAt("    --To start, press ENTER--   ", 0, 10);
            WriteAt("  ============================  ", 0, 11);
            Console.ReadLine();


            while (gameOver == false)
            {
                Console.Clear();

                
                if (cycle == 2)
                {
                    devi += 1;
                    cycle = 0;
                }
                cycle += 1;
                if (devi >= 6)
                {
                    devi = 0;
                }
                if (obstaclesY[devi] >= 40)
                {
                    obstaclesX[devi] = rnd.Next(1, 4);
                    obstaclesY[devi] = 0;
                }

                for (int i = 0; i < 4; i++)
                {
                    Road background = new Road(road, height);
                    road += 1;

                    if (road > 3)
                    {
                        road = 1;
                    }

                    obstaclesY[0] += 1;
                    obstaclesY[1] += 1;
                    obstaclesY[2] += 1;
                    obstaclesY[3] += 1;
                    obstaclesY[4] += 1;
                    obstaclesY[5] += 1;

                    Obstacle[] obstacles = { new Obstacle(obstaclesX[0], obstaclesY[0]), new Obstacle(obstaclesX[1], obstaclesY[1]),
                        new Obstacle(obstaclesX[2], obstaclesY[2]), new Obstacle(obstaclesX[3], obstaclesY[3]),
                        new Obstacle(obstaclesX[4], obstaclesY[4]), new Obstacle(obstaclesX[5], obstaclesY[5]) };

                    WriteAt("|", 0, 0);
                    
                    Car player = new Car(playerX, playerY);

                    Thread.Sleep(100);
                }


                if (obstaclesX[0] == playerX && obstaclesY[0] == 36)
                {
                    gameOver = true;
                }
                if (obstaclesX[1] == playerX && obstaclesY[1] == 36)
                {
                    gameOver = true;
                }
                if (obstaclesX[2] == playerX && obstaclesY[2] == 36)
                {
                    gameOver = true;
                }
                if (obstaclesX[3] == playerX && obstaclesY[3] == 36)
                {
                    gameOver = true;
                }
                if (obstaclesX[4] == playerX && obstaclesY[4] == 36)
                {
                    gameOver = true;
                }
                if (obstaclesX[5] == playerX && obstaclesY[5] == 36)
                {
                    gameOver = true;
                }


            Input:
                playerInput = Console.ReadKey(true);

                if (playerInput.Key == ConsoleKey.A && playerX > 1)
                {
                    playerX -= 1;
                }
                else if (playerInput.Key == ConsoleKey.D && playerX < 3)
                {
                    playerX += 1;
                }
                else if (playerInput.Key == ConsoleKey.W)
                {
                    continue;
                }
                else if (playerInput.Key == ConsoleKey.Escape)
                {
                    goto Start;
                }
                else
                {
                    goto Input;
                }
            }

            Console.Clear();
            WriteAt("  ============================  ", 0, 1);
            WriteAt("         --GAME OVER--          ", 0, 2);
            WriteAt("   --Press ENTER to continue--  ", 0, 3);
            WriteAt("  ============================  ", 0, 4);
            Console.ReadLine();
        }
    }
}
