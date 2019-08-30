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
    }
}
