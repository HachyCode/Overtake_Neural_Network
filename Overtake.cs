using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Overtake_Neural_Network
{
    class Overtake : Settings
    {

        private static readonly List<string> PossibleResults = new List<string> { "True", "False" };

        private static readonly AI_NeuralNetwork network = new AI_NeuralNetwork(inputNodes, hiddenNodes, outputNodes, learningRate);

        public static void Run()
        {
            Model.Randomrepetable(true);

            TrainingDataSetUp();
            trainingData = dataForTraining;

            TrainData();

            TestTraindAI();
        }

        private static void TrainingDataSetUp()
        {
            string[] dataset = File.ReadAllLines(filePath);

            string[][] allInputs = dataset
                .Select(x => x.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)).ToArray();

            dataCountAmount = Convert.ToInt32(allInputs.Length * fileSize);

            View.PrintText($"Total Data: {allInputs.Length}");
            View.PrintText($"Data used for training: {dataCountAmount}");
            View.PrintText($"Epochs: {epochs}");

            mixedata = Model.Mix(allInputs);

            dataForTraining = allInputs.Take(dataCountAmount).ToArray();
        }

        private static void TrainData()
        {
            for (var epoch = 0; epoch < epochs; epoch++)
            {
                View.PrintTextPlacement($"epoch: {epoch}", 1, 4);
                foreach (var input in trainingData)
                {
                    var inputList = input.Take(inputNodes).Select(double.Parse).ToArray();
                    var targets = new[] { 0.1, 0.1 };
                    targets[PossibleResults.IndexOf(input.Last())] = 0.99;
                    network.Train(NormaliseData(inputList), targets);
                }
            }
        }

        private static void TestTraindAI()
        {
            var testDataset = mixedata.Skip(dataCountAmount).ToArray();

            View.PrintText($"{testDataset.Length}");

            var scoreCard = new List<bool>();

            foreach (var input in testDataset)
            {
                var result = network.Query(NormaliseData(input.Take(3).Select(double.Parse).ToArray())).ToList();
                var predictedResult = PossibleResults[result.IndexOf(result.Max())];

                var correctResult = PossibleResults[PossibleResults.IndexOf(input.Last())];

                scoreCard.Add(predictedResult == correctResult);

                var miss = (predictedResult == correctResult) ? "" : "miss";

                View.PrintText($"{input[0],4}, {input[1],4}, {input[2],4}, {correctResult,-10}, {predictedResult,-10} {miss}");
            }
            View.PrintText($"Performance is {(scoreCard.Count(x => x) / Convert.ToDouble(scoreCard.Count)) * 100} percent out of {testDataset.Length}");
        }

        private static double[] NormaliseData(double[] input)
        {
            double initialSeparation     = 251.5;
            double overtakingSpeed       = 23.4;
            double oncomingSpeed         = 18.1;

            double[] normalised = new double[]
            {
                (input[0]/initialSeparation),
                (input[1]/overtakingSpeed  ),
                (input[2]/oncomingSpeed    ),
            };

            return normalised;
        }
    }
}
