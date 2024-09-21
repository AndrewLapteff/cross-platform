using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{

    internal class DominoCounter
    {
        private FileHandler _fileHandler;

        public DominoCounter()
        {
            _fileHandler = new FileHandler();
        }

        public void CalculateAndWriteDominoPoints(string inputFilePath, string outputFilePath)
        {
            try
            {
                string inputContent = _fileHandler.ReadFile(inputFilePath);

                if (_fileHandler.IsValidMaxDominoPoint(inputContent))
                {
                    int maxPoints = Convert.ToInt32(inputContent);
                    int totalPoints = CalculateTotalDominoPoints(maxPoints);

                    string message = $"Total domino points: {totalPoints}";
                    Console.WriteLine(message);
                    _fileHandler.WriteFile(outputFilePath, message);
                }
                else
                {
                    string message = "Invalid input. Max domino point should be > 0 and < 1000";
                    Console.WriteLine(message);
                    _fileHandler.WriteFile(outputFilePath, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                _fileHandler.WriteFile(outputFilePath, "Error: Invalid input or max domino point is not less than 1000");
            }
        }

        internal int CalculateTotalDominoPoints(int maxPoints)
        {
            int totalPoints = 0;

            for (int i = 0; i <= maxPoints; i++)
            {
                for (int j = i; j <= maxPoints; j++)
                {
                    totalPoints += i + j;
                }
            }

            return totalPoints;
        }
    }
}
