using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrivingSimQuestionmark
{
    class Road
    {
        int height;

        public Road(int x, int y)
        {
            height = y;

            if (x == 1)
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("||        |        |        ||", 0, i);
                    Program.WriteAt("||                          ||", 0, i + 1);
                    Program.WriteAt("||                          ||", 0, i + 2);
                }
            }

            if (x == 2)
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("||                          ||", 0, i);
                    Program.WriteAt("||        |        |        ||", 0, i + 1);
                    Program.WriteAt("||                          ||", 0, i + 2);
                }
            }

            if (x == 3)
            {
                for (int i = 0; i < height; i += 3)
                {
                    Program.WriteAt("||                          ||", 0, i);
                    Program.WriteAt("||                          ||", 0, i + 1);
                    Program.WriteAt("||        |        |        ||", 0, i + 2);
                }
            }
        }
    }
}
