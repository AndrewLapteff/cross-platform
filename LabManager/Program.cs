using System;
using System.Diagnostics;
using McMaster.Extensions.CommandLineUtils;

[Command(
    Name = "LabManager",
    Description = "Manage and execute lab projects"
    )]
[Subcommand(typeof(RunCommand)), Subcommand(typeof(TestCommand)), Subcommand(typeof(BuildCommand))]
class Program
{
    public static int Main(string[] args) => CommandLineApplication.Execute<Program>(args);

    [Option(Description = "Print version")]
    public bool Version { get; }

    private void OnExecute()
    {
        if (Version)
        {
            Console.WriteLine("LabManager v1.0.0 by Andriy Lapteff IPZ-33");
            return;
        }

        Console.WriteLine("Specify --help for a list of available options and commands.");
    }
}