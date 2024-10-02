﻿using lab1;
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
            string inputFilePath = "input.txt";
            string outputFilePath = "output.txt";

            var dominoCounter = new DominoCounter();
            dominoCounter.CalculateAndWriteDominoPoints(inputFilePath, outputFilePath);
        }
    }
}