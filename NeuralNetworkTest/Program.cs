using System;

namespace NeuralNetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            int[] layerSizes = new int[]{2, 1, 1};
            double[] inputs = new double[] { 1d, 1d};
            double[] nodeBiases = new double[] {1d, 1d};
            double[] connectionWegiths = new double[] { 1d, 1d, 1d};
            InstanceValues instanceValues = new InstanceValues(layerSizes, inputs, nodeBiases, connectionWegiths);
            double[] outputs = Instance.CalculateOutputs(instanceValues);

            Console.WriteLine(outputs[0]);

            int[] layerSizess = new int[] {2, 3, 3, 2};
            double[] inputValues = new double[] { 1d, 1d };
            InstanceValues instanceValuess = InstanceValues.CreateBaseInstanceValues(layerSizess, inputValues, 0, 1);

            InstanceValues iv = new InstanceValues(instanceValuess);
            iv.NewInputs(new double[] { 3d, 3d});


            double[] outputss = Instance.CalculateOutputs(instanceValuess);
            Console.WriteLine(outputss[0] + " | " + outputss[1]);

            double[] outputsCopied = Instance.CalculateOutputs(iv);
            Console.WriteLine(outputsCopied[0] + " | " + outputsCopied[1]);


            Console.ReadKey();
        }
    }
}
