using McMaster.Extensions.CommandLineUtils;

[Command(Name = "test", Description = "Тестування конкретної лабораторії")]
public class TestCommand
{
    [Argument(0, "lab", "Вкажіть лабораторію для тестування (1, 2 або 3)")]
    public int Lab { get; }

    [Option(Description = "Шлях до папки з вхідними та вихідними файлами", ShortName = "p")]
    public string Path { get; }

    private int OnExecute()
    {
        if (Lab < 1 || Lab > 3)
        {
            Console.WriteLine("Невірна лабораторія. Будь ласка, вкажіть 1, 2 або 3.");
            return 1;
        }

        string basePath = Path ?? Environment.GetEnvironmentVariable("LAB_PATH") ?? Environment.CurrentDirectory;

        MsBuildHelper.ExecuteMsBuild("test", Lab, path: basePath);
        return 0;
    }
}