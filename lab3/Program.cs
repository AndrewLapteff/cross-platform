using lab3;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Вызываем статический метод решения из класса PaperCuttingSolver
            int result = PaperCuttingSolver.Solve("input3.txt", "output3.txt");

            // Дополнительный вывод в консоль (необязательно)
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}