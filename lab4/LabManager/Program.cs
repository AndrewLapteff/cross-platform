using System;
using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

[Command(
    Name = "LabManager",
    Description = "Керування та виконання лабораторних проектів"
    )]
[Subcommand(typeof(RunCommand)), Subcommand(typeof(TestCommand)), Subcommand(typeof(BuildCommand)), Subcommand(typeof(SetPathCommand))]
class Program
{
    public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    [Option(Description = "Друк версії")]
    public bool Version { get; }

    private void OnExecute()
    {
        if (Version)
        {
            Console.WriteLine("LabManager v1.0.0 від Андрія Лаптєва ІПЗ-33");
            return;
        }

        Console.WriteLine("Вкажіть --help для списку доступних опцій та команд.");
    }
}