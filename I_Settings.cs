using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtake_Neural_Network
{
    interface I_Settings
    {
        static string filePath;

        static int epochs;

        static int inputNodes;
        static int hiddenNodes;
        static int outputNodes;

        static double learningRate;

        static double fileSize;
        static string[][] trainingData { get; set; }
        static int dataCountAmount { get; set; }
        static string[][] dataForTraining { get; set; }
        static string[][] mixedata { get; set; }
    }
}
