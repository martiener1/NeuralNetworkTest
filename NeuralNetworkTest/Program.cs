using System;

namespace NeuralNetworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("automatically created instancevalues with base values:");

            int[] layerSizess = new int[] {2, 3, 3, 2};
            double[] inputValuess = new double[] { 1d, 1d };
            InstanceValues instanceValuess = InstanceValues.CreateBaseInstanceValues(layerSizess, inputValuess, 0, 1);
            
            double[] outputss = Instance.CalculateOutputs(instanceValuess);
            Console.WriteLine(outputss[0] + " | " + outputss[1]);

            Console.WriteLine("automatically created instancevalues with random values:");

            int[] layerSizes = new int[] { 2, 3, 3, 2 };
            double[] inputValues = new double[] { 1d, 1d };
            InstanceValues instanceValues = InstanceValues.CreateRandomInstanceValues(layerSizes, inputValues, new Random());

            double[] outputs = Instance.CalculateOutputs(instanceValues);
            Console.WriteLine(outputs[0] + " | " + outputs[1]);

            Console.ReadKey();
        }
    }
}
