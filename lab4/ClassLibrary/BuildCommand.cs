using McMaster.Extensions.CommandLineUtils;

[Command(Name = "build", Description = "Build a specific lab")]
public class BuildCommand
{
    [Argument(0, "lab", "Specify the lab to build (1, 2, or 3)")]
    public int Lab { get; }

    private int OnExecute()
    {
        if (Lab < 1 || Lab > 3)
        {
            Console.WriteLine("Invalid lab. Please specify 1, 2, or 3.");
            return 1;
        }

        MsBuildHelper.ExecuteMsBuild("build", Lab);
        return 0;
    }
}

