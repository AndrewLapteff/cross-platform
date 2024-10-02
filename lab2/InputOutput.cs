using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    public class InputOutput
    {
        public static (int, int, int, int, int, List<int>, int, List<int>) ReadInput(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            // Читання перших двох рядків
            string[] firstLine = lines[0].Split();
            int n = int.Parse(firstLine[0]);
            int k = int.Parse(firstLine[1]);

            string[] secondLine = lines[1].Split();
            int w = int.Parse(secondLine[0]);
            int dw = int.Parse(secondLine[1]);
            int s = int.Parse(secondLine[2]);

            List<int> weeklyRestDays = new List<int>();
            if (dw > 0)
            {
                string[] thirdLine = lines[2].Split();
                foreach (var day in thirdLine)
                {
                    weeklyRestDays.Add(int.Parse(day));
                }
            }

            // Читання святкових днів
            int dm = int.Parse(lines[3]);
            List<int> monthlyRestDays = new List<int>();
            if (dm > 0)
            {
                string[] fourthLine = lines[4].Split();
                foreach (var day in fourthLine)
                {
                    monthlyRestDays.Add(int.Parse(day));
                }
            }

            return (n, k, w, dw, s, weeklyRestDays, dm, monthlyRestDays);
        }

        public static void WriteOutput(string filePath, int result)
        {
            File.WriteAllText(filePath, result.ToString());
        }
    }
}
