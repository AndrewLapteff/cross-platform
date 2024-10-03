using System.Linq;

namespace lab2
{
    public class OlympiadScheduler
    {
        public int CalculateOlympiadDays(int n, int k, int w, int dw, int s, int[] weeklyRestDays, int dm, int[] monthlyRestDays)
        {
            int[] dp = new int[n];

            // Marking weekly rest days
            for (int j = 0; j < dw; j++)
            {
                int h = weeklyRestDays[j];
                for (int i = (h - s + w) % w; i < n; i += w)
                {
                    dp[i] = -1; // Mark rest days as -1
                }
            }

            // Marking holidays
            for (int j = 0; j < dm; j++)
            {
                int h = monthlyRestDays[j];
                dp[h - 1] = -1; // Mark holidays as -1
            }

            // Calculate available days after the last rest day
            dp[0] = dp[0] == -1 ? 0 : 1; // Handle the first day
            for (int i = 1; i < n; i++)
            {
                if (dp[i] == -1)
                {
                    dp[i] = 0; // Day is not available
                }
                else
                {
                    dp[i] = dp[i - 1] + 1; // Increment the available day counter
                }
            }

            // Count valid periods of length k
            return dp.Count(e => e >= k); // Count periods using LINQ
        }
    }
}