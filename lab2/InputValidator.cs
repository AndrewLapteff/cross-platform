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

            if (input.Length < 5)
                throw new ArgumentException("Некорректные данные во входном файле.");

            int n = input[0];
            int k = input[1];
            int w = input[2];
            int dw = input[3];
            int s = input[4];

            int index = 5;
            if (input.Length < index + dw)
                throw new ArgumentException("Недостаточно данных для выходных дней.");

            int[] weeklyRestDays = new int[dw];
            for (int j = 0; j < dw; j++)
            {
                weeklyRestDays[j] = input[index++];
            }

            if (index >= input.Length)
                throw new ArgumentException("Некорректные данные для праздничных дней.");

            int dm = input[index++];

            if (dm < 0 || index + dm > input.Length)
                throw new ArgumentException("Некорректные данные для праздничных дней.");

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
