using System;

namespace lab2
{
    class Program
    {
        static void Main()
        {
            try
            {
                string inputFilePath = "input2.txt";
                string outputFilePath = "output2.txt";

                if (!System.IO.File.Exists(inputFilePath))
                {
                    Console.WriteLine("Файл input2.txt не знайдено.");
                    return;
                }

                InputOutputHandler ioHandler = new InputOutputHandler();
                OlympiadScheduler scheduler = new OlympiadScheduler();

                var (n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays) = ioHandler.ReadInput(inputFilePath);

                int result = scheduler.CalculateOlympiadDays(n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);

                ioHandler.WriteOutput(outputFilePath, result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}
