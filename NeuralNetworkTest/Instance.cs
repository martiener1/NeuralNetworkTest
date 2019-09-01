using System;
using System.Collections.Generic;
using System.Text;

namespace NeuralNetworkTest
{
    class Instance
    {

        

        public static double[] CalculateOutputs(InstanceValues instanceValues)
        {
            int[] layerSizes = instanceValues.layerSizes;
            double[] inputs = instanceValues.inputs;
            double[] nodeBiases = instanceValues.nodeBiases;
            double[] connectionWeights = instanceValues.connectionWeights;
            
            int nodeBiasCounter = 0;
            int connectionWeightCounter = 0;
            double[] currentNodeValues = new double[layerSizes[0]];

            for (int i = 0; i < layerSizes[0]; i++)
            {
                currentNodeValues[i] = inputs[i];
            }

            for (int i = 1; i < layerSizes.Length; i++)
            {
                // for every layer of nodes except the input layer
                int amountOfNewNodes = layerSizes[i];
                double[] newNodeBiases = new double[amountOfNewNodes];
                Array.Copy(nodeBiases, nodeBiasCounter, newNodeBiases, 0, amountOfNewNodes);
                nodeBiasCounter += amountOfNewNodes;

                int amountOfConnections = layerSizes[i-1] * layerSizes[i];
                double[] connectionWeightsForThisLayer = new double[amountOfConnections];
                Array.Copy(connectionWeights, connectionWeightCounter, connectionWeightsForThisLayer, 0, amountOfConnections);
                connectionWeightCounter += amountOfConnections;
                currentNodeValues = CalculateNextLayer(currentNodeValues, newNodeBiases, connectionWeightsForThisLayer);
            }
            return currentNodeValues;
        }


        private static double[] CalculateNextLayer(double[] previousNodes, double[] newNodeBiases, double[] connectionWeights)
        {
            int amountPreviousNodes = previousNodes.Length;
            int amountNewNodes = newNodeBiases.Length;
            int connectionWeightsCounter = 0;
            int nodeCounter = 0;
            double[] newNodeValues = new double[amountNewNodes];
            for (int i = 0; i < amountNewNodes; i++)
            {
                // for each new node
                double value  = newNodeBiases[nodeCounter++];
                for (int j = 0; j < previousNodes.Length; j++)
                {
                    // for each previous node
                    double previousNodeValue = previousNodes[j];
                    value += previousNodeValue * connectionWeights[connectionWeightsCounter++];
                }
                newNodeValues[i] = ActivationFunction(value);
            }
            return newNodeValues;
        }

        private static double ActivationFunction(double value)
        {
            // this will be a simpler and faster method than the sigmoid function, but the results will be close
            return 1d / (1d + Exp(-value));
        }

        private static double Exp(double val)
        {
            // approximation of e^x
            long tmp = (long)(1512775 * val + 1072632447);
            return BitConverter.Int64BitsToDouble(tmp << 32);
        }
    }
}
