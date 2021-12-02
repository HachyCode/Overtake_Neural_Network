using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtake_Neural_Network
{
    class Model
    {
        public static Random Random;
        public Model()
        {
            Overtake.Run();
        }

        public static void Randomrepetable(bool repetable)
        {
            if(repetable)
            {
                Random = new Random(0);
            }
            else
            {
                Random = new Random();
            }
        }

        public static string[][] Mix(string[][] inputes)
        {
            return inputes.OrderBy(x => Model.Random.NextDouble()).ToArray();
        }

        public static double[][] Mix(double[][] inputes)
        {
            return inputes.OrderBy(x => Model.Random.NextDouble()).ToArray();
        }
    }
}
