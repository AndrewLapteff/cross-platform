using McMaster.Extensions.CommandLineUtils;

[Command(Name = "set-path", Description = "Встановити шлях до папки з вхідними та вихідними файлами")]
public class SetPathCommand
{
    [Option("-p|--path <PATH>", "Вкажіть шлях до папки", CommandOptionType.SingleValue)]
    public string Path { get; }

    private int OnExecute()
    {
        if (string.IsNullOrEmpty(Path))
        {
            Console.WriteLine("Помилка: шлях обов'язковий.");
            return 1;
        }

        Console.WriteLine($"LAB_PATH встановлено на: {Path}");
        Environment.SetEnvironmentVariable("LAB_PATH", Path);
        return 0;
    }
}