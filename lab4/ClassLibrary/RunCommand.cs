using McMaster.Extensions.CommandLineUtils;

[Command(Name = "run", Description = "Run a specific lab")]
public class RunCommand
{
    [Argument(0, "lab", "Specify the lab to run (1, 2, or 3)")]
    public int Lab { get; }

    [Option(Description = "Path to the input file", ShortName = "i")]
    public string InputFile { get; }

    [Option(Description = "Path to the output file", ShortName = "o")]
    public string OutputFile { get; }

    private int OnExecute()
    {
        if (Lab < 1 || Lab > 3)
        {
            Console.WriteLine("Invalid lab. Please specify 1, 2, or 3.");
            return 1;
        }
        Console.WriteLine("RunCommand.cs:", InputFile, OutputFile);
        MsBuildHelper.ExecuteMsBuild("run", Lab, InputFile, OutputFile);
        return 0;
    }
}