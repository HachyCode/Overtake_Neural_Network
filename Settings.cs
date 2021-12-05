using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overtake_Neural_Network
{
    class Settings : I_Settings
    {
        protected static readonly string filePath = (@"C:\Users\Viktorija Pheonix\Documents\Programing\Level_6\Assignement SEM1 AI\OvertakeData_1000.csv");

        protected static readonly int epochs = 500;

        protected static readonly int inputNodes = 3;
        protected static readonly int hiddenNodes = 5;
        protected static readonly int outputNodes = 2;

        protected static readonly double learningRate = 0.1;

        protected static readonly double fileSize = 0.50;
        protected static string[][] trainingData { get; set; }
        protected static int dataCountAmount { get; set; }
        protected static string[][] dataForTraining { get; set; }
        protected static string[][] mixedata { get; set; }
    }
}
