using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    class Road
    {
        int height; //Hur många rader gånger 3 vägen är

        public Road(int cycle, int y) //Funktion som skriver ut vägen
        {
            height = y;

            if (cycle == 1) //Första "framen"
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("|||        |        |        |||", 0, i);
                    Program.WriteAt("||                            ||", 0, i + 1);
                    Program.WriteAt("||                            ||", 0, i + 2);
                }
            }

            else if (cycle == 2) //Andra "framen"
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("||                            ||", 0, i);
                    Program.WriteAt("|||        |        |        |||", 0, i + 1);
                    Program.WriteAt("||                            ||", 0, i + 2);
                }
            }

            else if (cycle == 3) //Tredje "framen"
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("||                            ||", 0, i);
                    Program.WriteAt("||                            ||", 0, i + 1);
                    Program.WriteAt("|||        |        |        |||", 0, i + 2);
                }
            }
        }
    }
}
