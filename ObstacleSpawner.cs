using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class ObstacleSpawner
    {
        public readonly int prefab; //Vilken "prefab" att spawna
        int posY; //Hindrens position i rader
        Random rnd = new Random();

        public ObstacleSpawner(int x, int y)
        {
            posY = y;
            if (0 < x && x < 7) //Kollar ifall man manuellt vill spawna en viss prefab
            {
                prefab = x;
            }
            else //Randomisar vilken prefab som ska spawnas
            {
                prefab = rnd.Next(1, 7);
            }

            if (prefab == 1) //Spawnar ett hinder på vänster sida
            {
                Obstacle obstacle = new Obstacle(1, posY);
            }
            else if (prefab == 2) //Spawnar ett hinder i mitten
            {
                Obstacle obstacle = new Obstacle(2, posY);
            }
            else if (prefab == 3) //Spawnar ett hinder på höger sida
            {
                Obstacle obstacle = new Obstacle(3, posY);
            }
            else if (prefab == 4) //Spawnar ett hinder på vänster sida och ett i mitten
            {
                Obstacle[] obstacles = { new Obstacle(1, posY), new Obstacle(2, posY) };
            }
            else if (prefab == 5) //Spawnar ett hinder i mitten och på höger sida
            {
                Obstacle[] obstacles = { new Obstacle(2, posY), new Obstacle(3, posY) };
            }
            else if (prefab == 6) //Spawnar ett hinder på vänster sida och ett på höger sida
            {
                Obstacle[] obstacles = { new Obstacle(1, posY), new Obstacle(3, posY) };
            }
        }
    }
}
