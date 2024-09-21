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
            string inputFilePath = "input.txt"; 
            string outputFilePath = "output.txt";  
            var dominoSet = new DominoSet();
            var validation = new Validation();
            int totalPoints = 0;

            try
            {
                string inputContent = File.ReadAllText(inputFilePath).Trim();
                
                if (validation.IsValidNumber(inputContent))
                {
                    int input = Convert.ToInt32(inputContent);
                    totalPoints = dominoSet.CalculateTotalPoints(input);

                    string message = $"Результат: {totalPoints}";
                    Console.WriteLine(message);
                    File.WriteAllText(outputFilePath, message);
                }
                else
                {
                    string message = "Файл не має містити символів. N > 0, N < 1000";
                    Console.WriteLine(message);
                    File.WriteAllText(outputFilePath, message);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                File.WriteAllText(outputFilePath, "Файл не має містити символів та число має бути менше 1000");
            }



        }
    }
}
