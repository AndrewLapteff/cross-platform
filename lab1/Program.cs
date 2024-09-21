using lab1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace crossplatform
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
                int input = Convert.ToInt32(inputContent);
                
                if (validation.IsValidNumber(inputContent))
                {
                    totalPoints = dominoSet.CalculateTotalPoints(input);

                    File.WriteAllText(outputFilePath, $"Результат: {totalPoints}");
                }
                else
                {
                    File.WriteAllText(outputFilePath, "Файл не має містити символів та число має бути менше 1000");
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
