namespace lab3 
{
    class Program
    {
        static void Main(string[] args)
        {
            // Чтение входных данных через InputOutput класс
            InputOutput io = new InputOutput();
            int[,] grid = io.ReadInput("input3.txt");

            // Подсчет частей
            Grid gridObj = new Grid(grid);
            int result = gridObj.CountParts();

            // Запись результата
            io.WriteOutput("output3.txt", result);
        }
    }
}