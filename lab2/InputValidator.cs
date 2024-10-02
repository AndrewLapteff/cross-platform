using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class InputValidator
    {
        public static void ValidateInput(int n, int k, int w, int dw, int s, List<int> weeklyRestDays, int dm, List<int> monthlyRestDays)
        {
            // Валідація n та k
            if (n < 1 || k > n || n > 100000)
                throw new ArgumentException("n і k повинні задовольняти умову 1 ≤ k ≤ n ≤ 100000.");

            // Валідація w і dw
            if (w < 1 || w > n || dw < 0 || dw > w)
                throw new ArgumentException("w і dw повинні задовольняти умову 1 ≤ w ≤ n і 0 ≤ dw ≤ w.");

            // Валідація s
            if (s < 1 || s > w)
                throw new ArgumentException("s повинно задовольняти умову 1 ≤ s ≤ w.");

            // Валідація щотижневих вихідних днів
            foreach (var day in weeklyRestDays)
            {
                if (day < 1 || day > w)
                    throw new ArgumentException("Кожен день щотижневого вихідного повинен задовольняти умову 1 ≤ день ≤ w.");
            }

            // Валідація разових святкових днів
            foreach (var day in monthlyRestDays)
            {
                if (day < 1 || day > n)
                    throw new ArgumentException("Кожен день разового святкового повинен задовольняти умову 1 ≤ день ≤ n.");
            }
        }
    }
}
