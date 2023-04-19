using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    internal class Obstacle
    {
        int posX; //Hindrets position i tiles
        int posY; //I rader

        public Obstacle(int x, int y) //Funktion som skriver ut hinder
        {
            if (x == 1) //Omvandlar position i tiles till position i kolumner så att funktionen WriteAt skriver ut hindret på rätt plats
            {
                posX = 3;
            }
            else if (x == 2)
            {
                posX = 12;
            }
            else if (x == 3)
            {
                posX = 21;
            }
            else //Ifall 'x' är något annat än 1,2 eller 3 skrivs bilen ut i mitten
            {
                posX = 12;
            }

            posY = y;

            Program.WriteAt("+======+", posX, posY); //Skriver ut hindret
            Program.WriteAt("|######|", posX, posY + 1);
            Program.WriteAt("|######|", posX, posY + 2);
            Program.WriteAt("+======+", posX, posY + 3);
        }
    }
}
