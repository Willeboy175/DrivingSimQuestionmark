using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Car
    {
        int posX; //Vilken position bilen har i tiles
        int posY;

        public Car(int x, int y) //Funktion som skriver ut en bil
        {
            if (x == 1) //Omvandlar position i tiles till position i kolumner
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
            else //Ifall 'x' är något annat än 1,2 eller 3 skrivs bilen ut i mitten
            {
                posX = 13;
            }

            posY = y * 4; //Omvandlar position i tiles till position i rader

            Program.WriteAt("[¨¨¨¨]", posX, posY); //Skriver ut bilen
            Program.WriteAt("|›__‹|", posX, posY + 1);
            Program.WriteAt("||__||", posX, posY + 2);
            Program.WriteAt("[____]", posX, posY + 3);
        }
    }
}
