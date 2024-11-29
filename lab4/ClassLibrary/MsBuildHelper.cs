using System;
using System.Diagnostics;

public static class MsBuildHelper
{
    public static void ExecuteMsBuild(string task, int lab, string input = "input.txt", string output = "output.txt", string path = "")
    {
        try
        {
            string pathArgument = string.IsNullOrEmpty(path) ? "" : $"/p:Path={path}";
            ProcessStartInfo startInfo = new ProcessStartInfo
            {
                FileName = "msbuild",
                Arguments = $"build.proj /t:{task} /p:lab={lab} /p:InputFile={input} /p:OutputFile={output} /p:Path={pathArgument}",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            using (Process process = Process.Start(startInfo))
            {
                process.OutputDataReceived += (sender, e) => Console.WriteLine(e.Data);
                process.ErrorDataReceived += (sender, e) => Console.Error.WriteLine(e.Data);

                process.BeginOutputReadLine();
                process.BeginErrorReadLine();
                process.WaitForExit();
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Не вдалося виконати завдання MSBuild: {ex.Message}");
        }
    }
}