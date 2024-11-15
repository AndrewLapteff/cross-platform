using System;

namespace lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string inputFilePath = "input2.txt";
                string outputFilePath = "output2.txt";

                for (int i = 0; i < args.Length; i++)
                {
                    if ((args[i] == "-i" || args[i] == "--input") && i + 1 < args.Length)
                    {
                        inputFilePath = args[i + 1];
                    }
                    if ((args[i] == "-o" || args[i] == "--output") && i + 1 < args.Length)
                    {
                        outputFilePath = args[i + 1];
                    }
                }

                if (!System.IO.File.Exists(inputFilePath))
                {
                    Console.WriteLine($"File {inputFilePath} not found.");
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
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
