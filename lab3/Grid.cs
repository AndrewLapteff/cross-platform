using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab3
{
    class Grid
    {
        private int[,] grid;
        private bool[,] visited;
        private int rows, cols;

        public Grid(int[,] grid)
        {
            this.grid = grid;
            this.rows = grid.GetLength(0);
            this.cols = grid.GetLength(1);
            this.visited = new bool[rows, cols];
        }

        public int CountParts()
        {
            int count = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    if (grid[i, j] == 0 && !visited[i, j])
                    {
                        DFS(i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS(int row, int col)
        {
            if (row < 0 || row >= rows || col < 0 || col >= cols || visited[row, col] || grid[row, col] == 1)
            {
                return;
            }

            visited[row, col] = true;

            DFS(row - 1, col);
            DFS(row + 1, col);
            DFS(row, col - 1);
            DFS(row, col + 1);
        }
    }
}
