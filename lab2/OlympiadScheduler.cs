using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class OlympiadScheduler
    {
        public static int CalculateOlympiadDays(int n, int k, int w, int dw, int s, List<int> weeklyRestDays, int dm, List<int> monthlyRestDays)
        {
            int[] dp = new int[n];

            // Помітка щотижневих вихідних днів
            foreach (var day in weeklyRestDays)
            {
                for (int i = (day - s + w) % w; i < n; i += w)
                {
                    dp[i] = -1; // -1 означає вихідний
                }
            }

            // Помітка разових святкових днів
            foreach (var day in monthlyRestDays)
            {
                if (day - 1 < n) // Перевірка межі
                {
                    dp[day - 1] = -1; // -1 означає вихідний
                }
            }

            // Обчислення кількості доступних днів
            dp[0] = dp[0] == -1 ? 0 : 1;
            for (int i = 1; i < n; i++)
            {
                dp[i] = dp[i] == -1 ? 0 : dp[i - 1] + 1;
            }

            // Підрахунок кількості періодів довжиною k
            int validPeriods = dp.Count(e => e >= k);

            return validPeriods;
        }
    }
}
