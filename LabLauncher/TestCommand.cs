using McMaster.Extensions.CommandLineUtils;

[Command(Name = "test", Description = "Test a specific lab")]
public class TestCommand
{
    [Argument(0, "lab", "Specify the lab to test (1, 2, or 3)")]
    public int Lab { get; }

    private int OnExecute()
    {
        if (Lab < 1 || Lab > 3)
        {
            Console.WriteLine("Invalid lab. Please specify 1, 2, or 3.");
            return 1;
        }

        MsBuildHelper.ExecuteMsBuild("test", Lab);
        return 0;
    }
}