using lab3;
using System;
using System.IO;

public class PaperCuttingSolver
{
    public static int Solve(string inputFile, string outputFile)
    {
        int[,] matrix;
        int N, M;
        ReadInput(inputFile, out N, out M, out matrix);

        int result = CountParts(N, M, matrix);

        File.WriteAllText(outputFile, result.ToString());

        return result;
    }

    private static void ReadInput(string filename, out int N, out int M, out int[,] matrix)
    {
        string[] lines = File.ReadAllLines(filename);

        string[] sizes = lines[0].Split(' ');
        N = int.Parse(sizes[0]);
        M = int.Parse(sizes[1]);

        matrix = new int[N, M];

        for (int i = 0; i < N; i++)
        {
            string[] row = lines[i + 1].Split(' ');
            for (int j = 0; j < M; j++)
            {
                matrix[i, j] = int.Parse(row[j]);
            }
        }
    }

    private static void DFS(int[,] matrix, bool[,] visited, int x, int y, int N, int M)
    {
        if (x < 0 || x >= N || y < 0 || y >= M)
            return;

        if (visited[x, y] || matrix[x, y] == 1)
            return;

        visited[x, y] = true;

        int[,] directions = new int[,] { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        for (int k = 0; k < 4; k++)
        {
            int newX = x + directions[k, 0];
            int newY = y + directions[k, 1];
            DFS(matrix, visited, newX, newY, N, M);
        }
    }

    private static int CountParts(int N, int M, int[,] matrix)
    {
        bool[,] visited = new bool[N, M];

        int parts = 0;

        for (int x = 0; x < N; x++)
        {
            for (int y = 0; y < M; y++)
            {
                if (!visited[x, y] && matrix[x, y] == 0)
                {
                    DFS(matrix, visited, x, y, N, M);
                    parts++;
                }
            }
        }

        return parts;
    }
}