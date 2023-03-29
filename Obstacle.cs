using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Obstacle
    {
        int posX;
        int posY;

        public Obstacle(int x, int y)
        {
            if (x == 1)
            {
                posX = 2;
            }
            if (x == 2)
            {
                posX = 11;
            }
            if (x == 3)
            {
                posX = 20;
            }

            posY = y;

            Program.WriteAt("+======+", posX, posY);
            Program.WriteAt("|######|", posX, posY + 1);
            Program.WriteAt("|######|", posX, posY + 2);
            Program.WriteAt("+======+", posX, posY + 3);
        }
    }
}
