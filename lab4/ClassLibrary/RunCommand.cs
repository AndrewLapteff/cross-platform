using McMaster.Extensions.CommandLineUtils;

[Command(Name = "run", Description = "Запустити конкретну лабораторію")]
public class RunCommand
{
    [Argument(0, "lab", "Вкажіть лабораторію для запуску (1, 2 або 3)")]
    public int Lab { get; }

    [Option(Description = "Шлях до вхідного файлу", ShortName = "i")]
    public string InputFile { get; }

    [Option(Description = "Шлях до вихідного файлу", ShortName = "o")]
    public string OutputFile { get; }

    [Option(Description = "Шлях до папки з вхідними т�� вихідними файлами", ShortName = "p")]
    public string Path { get; }

    private int OnExecute()
    {
        if (Lab < 1 || Lab > 3)
        {
            Console.WriteLine("Невірна лабораторія. Будь ласка, вкажіть 1, 2 або 3.");
            return 1;
        }

        string basePath = Path ?? Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.CurrentDirectory;

        string inputFilePath = !string.IsNullOrEmpty(InputFile) ? $"{basePath}/{InputFile}" : $"{basePath}/input.txt";
        string outputFilePath = !string.IsNullOrEmpty(OutputFile) ? $"{basePath}/{OutputFile}" : $"{basePath}/output.txt";

        MsBuildHelper.ExecuteMsBuild("run", Lab, inputFilePath, outputFilePath, basePath);
        return 0;
    }
}