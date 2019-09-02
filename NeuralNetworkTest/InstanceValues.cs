using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class InstanceValues
    {
        public int[] layerSizes;
        public double[] inputs;
        public double[] nodeBiases;
        public double[] connectionWeights;

        public InstanceValues(int[] layerSizes,double[] inputs, double[] nodeBiases, double[] connectionWeights)
        {
            this.layerSizes = layerSizes;
            this.inputs = inputs;
            this.nodeBiases = nodeBiases;
            this.connectionWeights = connectionWeights;
        }

        public InstanceValues(InstanceValues instanceValues)
        {
            this.layerSizes = instanceValues.layerSizes;
            this.inputs = instanceValues.inputs;
            this.nodeBiases = instanceValues.nodeBiases;
            this.connectionWeights = instanceValues.connectionWeights;
        }

        public void NewInputs(double[] inputValues)
        {
            this.inputs = inputValues;
        }

        public InstanceValues Reproduce(int WeightsToChange, double maxChange, Random random)
        {
            InstanceValues returnValues = new InstanceValues(this);
            int nodeAmount = nodeBiases.Length;
            int connectionAmount = connectionWeights.Length;
            for (int i = 0; i < WeightsToChange; i++)
            {
                int weightToChange = random.Next(nodeAmount+connectionAmount);
                if (weightToChange < nodeAmount)
                {
                    returnValues.nodeBiases[weightToChange] += (random.NextDouble() - 0.5d) * 2 * maxChange;
                }
                else
                {
                    returnValues.connectionWeights[weightToChange - nodeAmount] += (random.NextDouble() - 0.5d) * 2 * maxChange;
                }
            }
            return returnValues;
        }

        public static InstanceValues CreateBaseInstanceValues(int[] layerSizes, double[] inputs, double nodeBaseBias, double connectionBaseWeight)
        {
            int nodeBiasAmount = 0;
            int connectionAmount = 0;

            for (int i = 1; i < layerSizes.Length; i++)
            {
                nodeBiasAmount += layerSizes[i];
                connectionAmount += layerSizes[i - 1] * layerSizes[i];
            }

            double[] nodeBiases = new double[nodeBiasAmount];
            Array.Fill<double>(nodeBiases, nodeBaseBias);
            double[] connectionWeights = new double[connectionAmount];
            Array.Fill<double>(connectionWeights, connectionBaseWeight);

            InstanceValues instanceValues = new InstanceValues(layerSizes, inputs, nodeBiases, connectionWeights);
            return instanceValues;
        }

        public static InstanceValues CreateRandomInstanceValues(int[] layerSizes, double[] inputs, Random random)
        {
            int nodeBiasAmount = 0;
            int connectionAmount = 0;

            for (int i = 1; i < layerSizes.Length; i++)
            {
                nodeBiasAmount += layerSizes[i];
                connectionAmount += layerSizes[i - 1] * layerSizes[i];
            }

            double[] nodeBiases = new double[nodeBiasAmount];
            for (int i = 0; i < nodeBiasAmount; i++)
            {
                nodeBiases[i] = random.NextDouble();
            }
            double[] connectionWeights = new double[connectionAmount];
            for (int i = 0; i< connectionAmount; i++)
            {
                connectionWeights[i] = random.NextDouble();
            }

            InstanceValues instanceValues = new InstanceValues(layerSizes, inputs, nodeBiases, connectionWeights);
            return instanceValues;
        }
        
    }
}
