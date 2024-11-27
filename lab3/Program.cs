using lab3;
using Lab3ClassLibrary;
using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            int result = PaperCuttingSolver.Solve("input3.txt", "output3.txt");

            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}