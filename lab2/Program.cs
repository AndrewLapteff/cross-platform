using System;

namespace lab2
{
    class Program
    {
        static void Main()
        {
            try
            {
                // Define input and output file paths
                string inputFilePath = "input2.txt";
                string outputFilePath = "output2.txt";

                // Check if the input file exists
                if (!System.IO.File.Exists(inputFilePath))
                {
                    Console.WriteLine("Файл input2.txt не знайдено.");
                    return;
                }

                // Create instances of our classes
                InputOutputHandler ioHandler = new InputOutputHandler();
                OlympiadScheduler scheduler = new OlympiadScheduler();

                // Read input from file
                var (n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays) = ioHandler.ReadInput(inputFilePath);

                // Perform calculation
                int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

                // Write result to file
                ioHandler.WriteOutput(outputFilePath, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
