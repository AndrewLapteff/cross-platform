using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class InputOutput
    {
        public int[,] ReadInput(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);
            string[] dimensions = lines[0].Split(' ');

            int n = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);
            Console.WriteLine(n);
            Console.WriteLine(m);
            int[,] grid = new int[n, m];

            for (int i = 0; i < n; i++)
            {
                string[] row = lines[i + 1].Split(' ');
                for (int j = 0; j < m; j++)
                {
                    grid[i, j] = int.Parse(row[j]);
                    Console.WriteLine(row[j]);
                }
            }

            return grid;
        }

        public void WriteOutput(string filePath, int result)
        {
            File.WriteAllText(filePath, result.ToString());
        }
    }
}
