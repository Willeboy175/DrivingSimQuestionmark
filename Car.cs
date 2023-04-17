using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Car
    {
        int posX;
        int posY;

        public Car(int x, int y)
        {
            if (x == 1)
            {
                posX = 4;
            }
            else if (x == 2)
            {
                posX = 13;
            }
            else if (x == 3)
            {
                posX = 22;
            }
            else
            {
                posX = 13;
            }

            posY = y * 4;

            Program.WriteAt("[¨¨¨¨]", posX, posY);
            Program.WriteAt("|›__‹|", posX, posY + 1);
            Program.WriteAt("||__||", posX, posY + 2);
            Program.WriteAt("[____]", posX, posY + 3);
        }
    }
}
