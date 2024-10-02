using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        try
        {
            // Читаем данные из файла input2.txt
            string inputFilePath = "input2.txt";
            string outputFilePath = "output2.txt";

            if (!File.Exists(inputFilePath))
            {
                Console.WriteLine("Файл input2.txt не знайдено.");
                return;
            }

            var input = File.ReadAllText(inputFilePath)
                            .Split(new[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries)
                            .Select(int.Parse)
                            .ToArray();

            // Проверяем минимальные размеры массива
            if (input.Length < 5)
            {
                Console.WriteLine("Некорректные данные во входном файле.");
                return;
            }

            // Читаем первый блок данных
            int n = input[0]; // количество дней в месяце
            int k = input[1]; // продолжительность олимпиады
            int w = input[2]; // количество дней в неделе
            int dw = input[3]; // количество выходных дней в неделе
            int s = input[4]; // день недели, с которого начинается месяц

            // Проверяем корректность данных
            if (n < 1 || n > 100000 || k < 1 || k > n || w < 1 || dw < 0 || dw > w || s < 1 || s > w)
            {
                Console.WriteLine("Некорректные данные во входном файле.");
                return;
            }

            // Инициализация массива
            int[] dp = new int[n];

            // Проверяем корректность входных данных для выходных дней
            int index = 5;
            if (input.Length < 5 + dw)
            {
                Console.WriteLine("Недостаточно данных для выходных дней.");
                return;
            }

            // Считываем выходные дни
            for (int j = 0; j < dw; j++)
            {
                int h = input[index++];
                if (h < 1 || h > w)
                {
                    Console.WriteLine("Некорректные номера выходных дней.");
                    return;
                }
                for (int i = (h - s + w) % w; i < n; i += w)
                {
                    dp[i] = -1; // Помечаем выходные как -1
                }
            }

            // Считываем количество праздничных дней
            if (index >= input.Length)
            {
                Console.WriteLine("Некорректные данные для праздничных дней.");
                return;
            }

            int dm = input[index++];
            if (dm < 0 || index + dm > input.Length)
            {
                Console.WriteLine("Некорректные данные для праздничных дней.");
                return;
            }

            // Считываем праздничные дни
            for (int j = 0; j < dm; j++)
            {
                int h = input[index++];
                if (h < 1 || h > n)
                {
                    Console.WriteLine("Некорректные номера праздничных дней.");
                    return;
                }
                dp[h - 1] = -1; // Помечаем праздники как -1
            }

            // Вычисляем количество дней с последнего выходного
            dp[0] = dp[0] == -1 ? 0 : 1; // Обрабатываем первый день
            for (int i = 1; i < n; i++)
            {
                if (dp[i] == -1)
                {
                    dp[i] = 0; // День недоступен
                }
                else
                {
                    dp[i] = dp[i - 1] + 1; // Увеличиваем счетчик дней
                }
            }

            // Считаем количество возможных периодов для проведения олимпиады
            int result = dp.Count(e => e >= k); // Используем LINQ для подсчета

            // Записываем результат в output2.txt
            File.WriteAllText(outputFilePath, result.ToString());
            Console.WriteLine($"Результат записан в {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }
}
