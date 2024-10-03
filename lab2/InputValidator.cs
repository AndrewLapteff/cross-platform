using System;
using System.IO;
using System.Linq;

namespace lab2
{
    public class InputOutputHandler
    {
        public (int, int, int, int, int, int[], int, int[]) ReadInput(string inputFilePath)
        {
            var input = File.ReadAllText(inputFilePath)
                            .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            // Check if we have at least 5 elements
            if (input.Length < 5)
                throw new ArgumentException("Некорректные данные во входном файле.");

            // Read the first block of data
            int n = input[0]; // Number of days in the month
            int k = input[1]; // Length of the olympiad
            int w = input[2]; // Number of days in the week
            int dw = input[3]; // Number of rest days in the week
            int s = input[4]; // Start day of the week

            // Ensure there is enough data for the rest days
            int index = 5;
            if (input.Length < index + dw)
                throw new ArgumentException("Недостаточно данных для выходных дней.");

            // Read weekly rest days
            int[] weeklyRestDays = new int[dw];
            for (int j = 0; j < dw; j++)
            {
                weeklyRestDays[j] = input[index++];
            }

            // Read the number of holiday days
            if (index >= input.Length)
                throw new ArgumentException("Некорректные данные для праздничных дней.");

            int dm = input[index++];

            if (dm < 0 || index + dm > input.Length)
                throw new ArgumentException("Некорректные данные для праздничных дней.");

            // Read monthly rest days
            int[] monthlyRestDays = new int[dm];
            for (int j = 0; j < dm; j++)
            {
                monthlyRestDays[j] = input[index++];
            }

            return (n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
        }

        public void WriteOutput(string outputFilePath, int result)
        {
            File.WriteAllText(outputFilePath, result.ToString());
            Console.WriteLine($"Результат записан в {outputFilePath}");
        }
    }
}
