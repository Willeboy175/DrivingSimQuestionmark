using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class ObstacleSpawner
    {
        int prefab;
        int posY;
        Random rnd = new Random();

        public ObstacleSpawner(int x, int y)
        {
            posY = y;

            if (0 < x && x < 7)
            {
                prefab = x;
            }
            else
            {
                prefab = rnd.Next(1, 7);
            }

            if (prefab == 1)
            {
                Obstacle obstacle = new Obstacle(1, posY);
            }
            else if (prefab == 2)
            {
                Obstacle obstacle = new Obstacle(2, posY);
            }
            else if (prefab == 3)
            {
                Obstacle obstacle = new Obstacle(3, posY);
            }
            else if (prefab == 4)
            {
                Obstacle[] obstacles = { new Obstacle(1, posY), new Obstacle(2, posY) };
            }
            else if (prefab == 5)
            {
                Obstacle[] obstacles = { new Obstacle(2, posY), new Obstacle(3, posY) };
            }
            else if (prefab == 6)
            {
                Obstacle[] obstacles = { new Obstacle(1, posY), new Obstacle(3, posY) };
            }
        }
    }
}
