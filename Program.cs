using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace DrivingSimQuestionmark
{
    internal class Program
    {
        protected static int origRow; //Offset för WriteAt funktionen i förhållande till övre vänstra hörnet i konsollen
        protected static int origCol;

        public static void WriteAt(string s, int x, int y) //Funktion för att skriva en string på positionen för 'x' och 'y'
        {
            try //Försöker skriva på vald position
            {
                //Sätter pekarens position i x- och y-led beroende på funktionens offset
                //Skriver på pekarens position
                Console.SetCursorPosition(origCol + x, origRow + y);
                Console.Write(s);
            }
            catch (ArgumentOutOfRangeException e) //Skapar ett felmeddelande ifall försöket misslyckas
            {
                Console.Clear();
                Console.WriteLine(e.Message); //Visar felmeddelandet
            }
        }

        static void Main(string[] args)
        {
        Start:
            int width = 32; //Storleken på konsollen
            int height = 45;
            bool gameOver = false;
            int road = 1; //Vilken "frame" animationen för vägen är på, kan vara 1,2 eller 3
            int Version;
            int score = -1;
            Random rnd = new Random();

            int playerX = 2; //Spelarens position i tiles
            int playerY = 9;
            ConsoleKeyInfo playerInput;

            int devi = 0; //Bestämmer vilken variabel i 'obstacles', 'obstaclesX' och 'obstaclesY' som används för att spawna en ett nytt hinder (inte så beskrivande namn men hade svårt att komma på ett namn för variabeln så jag tog bara kompisen jag satt i samtal med)
            int cycle = 0;
            int[] obstaclesX = { 2, 2, 2, 2, 2, 2 }; //Array för hindernas position i x-led i tile
            int[] obstaclesY = { 45, 45, 45, 45, 45, 45 }; //Array för hindernas position i y-led i rader


            origRow = Console.CursorTop; //Sätter offset för funktionen WriteAt
            origCol = Console.CursorLeft;
            Console.SetWindowSize(width, height);


            Console.Clear();
            WriteAt("================================", 0, 1); //Huvudmeny
            WriteAt("    --Press A to move left--    ", 0, 2);
            WriteAt("    --Press D to move right--   ", 0, 3);
            WriteAt("   --Press W to move nothing--  ", 0, 4);
            WriteAt("   --Press ESC to main menu--   ", 0, 5);
            WriteAt("================================", 0, 6);
            WriteAt("================================", 0, 9);
            WriteAt("--Write 1 to select version 1-- ", 0, 10);
            WriteAt("--Write 2 to select Version 2-- ", 0, 11);
            WriteAt("================================", 0, 12);
            WriteAt("================================", 0, 15);
            WriteAt("    --To start, press ENTER--   ", 0, 16);
            WriteAt("================================", 0, 17);
            WriteAt("          Version ", 0, 20);

            Version = int.Parse(Console.ReadLine());

            if (Version == 1) //Kollar så att gamemode inte är något annat än 1 eller 2
            {
                Console.Clear();
                WriteAt("          Version 1", 0, 10);
                Thread.Sleep(1000);
            }
            else if (Version == 2)
            {
                Console.Clear();
                WriteAt("          Version 2", 0, 10);
                Thread.Sleep(1000);
            }
            else
            {
                goto Start;
            }

            while (gameOver == false) 
            {
                Console.Clear();

                if (Version == 1) //Väljer rätt kod att utföra för vald version
                {
                    if (cycle == 2) //Byter till nästa variabel i 'obstacles', 'obstaclesX' och 'obstaclesY' varannan cykel
                    {
                        devi += 1;
                        cycle = 0;
                    }
                    cycle += 1; //Lägger till '+1' för varje cykel
                    if (devi >= 6) //Går tillbaka till första variabeln i 'obstacles', 'obstaclesX' och 'obstaclesY'
                    {
                        devi = 0;
                    }
                    if (obstaclesY[devi] >= 40) //Spawnar ett hinder på en slumpmässig plats på toppen av spelplanen
                    {
                        obstaclesX[devi] = rnd.Next(1, 4);
                        obstaclesY[devi] = 0;
                    }
                }
                else if (Version == 2) //Väljer rätt kod att utföra för vald version
                {
                    if (cycle == 3) //Byter till nästa variabel i 'obstacleSpawner', 'obstaclesX' och 'obstaclesY' var tredje cykel
                    {
                        devi += 1;
                        cycle = 0;
                    }
                    cycle += 1; //Lägger till '+1' för varje cykel
                    if (devi >= 6) //Går tillbaka till första variabeln i 'obstacleSpawner', 'obstaclesX' och 'obstaclesY'
                    {
                        devi = 0;
                    }
                    if (obstaclesY[devi] >= 40) //Spawnar ett hinder på en slumpmässig plats på toppen av spelplanen
                    {
                        obstaclesX[devi] = rnd.Next(1, 7);
                        obstaclesY[devi] = 0;
                    }
                }
                score += 1;//Lägger till '+1' för varje cykel

                for (int i = 0; i < 4; i++) //Animation för väg och hinder och skriver ut spelaren
                {
                    Road background = new Road(road, height); //Väg
                    road += 1;

                    if (road > 3) //Återställer cykeln för vägen
                    {
                        road = 1;
                    }

                    for (int n = 0; n < 6; n++) //Flyttar hinderna ner en rad
                    {
                        obstaclesY[n] += 1;
                    }

                    if (Version == 1) //Väljer rätt kod att utföra för vald version
                    {
                        //Skriver ut alla hinder
                        Obstacle[] obstacles = { new Obstacle(obstaclesX[0], obstaclesY[0]), new Obstacle(obstaclesX[1], obstaclesY[1]),
                            new Obstacle(obstaclesX[2], obstaclesY[2]), new Obstacle(obstaclesX[3], obstaclesY[3]),
                            new Obstacle(obstaclesX[4], obstaclesY[4]), new Obstacle(obstaclesX[5], obstaclesY[5]) };

                        for (int n = 0; n < 5; n++) //Kollar ifall något av hinderna är på samma plats som spelaren
                        {
                            if (obstaclesX[n] == playerX && obstaclesY[n] == 36)
                            {
                                gameOver = true;
                            }
                        }
                    }
                    else if (Version == 2) //Väljer rätt kod att utföra för vald version
                    {
                        //Skriver ut alla hinder
                        ObstacleSpawner[] obstacleSpawners = { new ObstacleSpawner(obstaclesX[0], obstaclesY[0]), new ObstacleSpawner(obstaclesX[1], obstaclesY[1]),
                            new ObstacleSpawner(obstaclesX[2], obstaclesY[2]), new ObstacleSpawner(obstaclesX[3], obstaclesY[3]),
                            new ObstacleSpawner(obstaclesX[4], obstaclesY[4]), new ObstacleSpawner(obstaclesX[5], obstaclesY[5]) };

                        for (int n = 0; n < 5; n++) //Kollar ifall något av hinderna är på samma plats som spelaren
                        {
                            if (obstacleSpawners[n].prefab == playerX && obstaclesY[n] == 36) //Kollar för prefab 1-3
                            {
                                gameOver = true;
                            }
                            if (obstacleSpawners[n].prefab == 4 && (playerX == 1 || playerX == 2) && obstaclesY[n] == 36) //Kollar för prefab 4
                            {
                                gameOver = true;
                            }
                            if (obstacleSpawners[n].prefab == 5 && (playerX == 2 || playerX == 3) && obstaclesY[n] == 36) //Kollar för prefab 5
                            {
                                gameOver = true;
                            }
                            if (obstacleSpawners[n].prefab == 6 && (playerX == 1 || playerX == 3) && obstaclesY[n] == 36) //Kollar för prefab 6
                            {
                                gameOver = true;
                            }
                        }
                    }

                    WriteAt("================================", 0, 42); //Skriver Score på botten av skärmen
                    WriteAt("       --Score: " + score+ "--             ", 0, 43);
                    WriteAt("================================", 0, 44);

                    WriteAt("|", 0, 0); //Skriver en sak högst upp i konsollen så att rätt saker alltid visas
                    
                    Car player = new Car(playerX, playerY); //Spelare

                    Thread.Sleep(100);
                }
                

                if (gameOver == false) //Skippar ifall spelet är slut
                {
                Input:
                    playerInput = Console.ReadKey(true); //Läser spelarens input

                    if (playerInput.Key == ConsoleKey.A && playerX > 1) //Flyttar spelaren åt vänster
                    {
                        playerX -= 1;
                    }
                    else if (playerInput.Key == ConsoleKey.D && playerX < 3) //Flyttar spelaren åt höger
                    {
                        playerX += 1;
                    }
                    else if (playerInput.Key == ConsoleKey.W) //Flyttar inte spelaren och fortsätter spelet
                    {
                        continue;
                    }
                    else if (playerInput.Key == ConsoleKey.Escape) //Går till 'Start:' som återställer spelet och tar spelaren till huvudmenyn
                    {
                        Console.Clear();
                        goto Start;
                    }
                    else //Går till 'Input:' som ser till att alla andra knappar på tangentbordet inte fortsätter spelet
                    {
                        goto Input;
                    }
                }
            }

            
        End:
            Console.Clear();
            WriteAt("================================", 0, 1); //Game over meny som också är slutet på spelet
            WriteAt("         --GAME OVER--          ", 0, 2);
            WriteAt("    --Your score is: " +score + "--        ", 0, 3);
            WriteAt("================================", 0, 4);
            WriteAt("================================", 0, 7);
            WriteAt("   --Press ENTER to continue--  ", 0, 8);
            WriteAt("================================", 0, 9);
            playerInput = Console.ReadKey(true); //Läser spelarens input

            if (playerInput.Key != ConsoleKey.Enter) //Avslutar spelet bara ifall spelaren trycker på Enter
            {
                goto End;
            }
        }
    }
}
