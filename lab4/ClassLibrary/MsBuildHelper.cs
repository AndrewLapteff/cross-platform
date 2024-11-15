using System;
using System.Diagnostics;

public static class MsBuildHelper
{
    public static void ExecuteMsBuild(string task, int lab, string input = "defaultInput.txt", string output = "defaultOutput.txt")
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "msbuild",
                Arguments = $"build.proj /t:{task} /p:lab={lab} /p:InputFile={input} /p:OutputFile={output}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(startInfo))
            {
                Console.WriteLine("MsBuildHelper.cs:", input, output);
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                process.ErrorDataReceived += (sender, e) => Console.Error.WriteLine(e.Data);

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to execute MSBuild task: {ex.Message}");
        }
    }
}