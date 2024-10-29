using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputFilePath = "input1.txt";
            string outputFilePath = "output1.txt";

            // Parse command-line arguments
            for (int i = 0; i < args.Length; i++)
            {
                if (args[i] == "-i" && i + 1 < args.Length)
                {
                    inputFilePath = args[i + 1];
                }
                else if (args[i] == "-o" && i + 1 < args.Length)
                {
                    outputFilePath = args[i + 1];
                }
            }

            var dominoCounter = new DominoCounter();
            dominoCounter.CalculateAndWriteDominoPoints(inputFilePath, outputFilePath);
        }
    }
}