using System.Diagnostics;
using System.Runtime.InteropServices;
using Microsoft.AspNetCore.Mvc;

namespace lab5.Controllers
{
    public class HomeController : Controller
    {
        private string RunCommand(string command)
        {
            string outputExecute;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                outputExecute = ExecuteCommand("cmd.exe", $"/c {command}");
            }
            else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                outputExecute = ExecuteCommand("/bin/bash", $"-c \"{command}\"");
            }
            else
            {
                outputExecute = "Unsupported operating system";
            }
            return outputExecute;
        }

        private string ExecuteCommand(string shell, string arguments)
        {
            var processInfo = new ProcessStartInfo
            {
                FileName = shell,
                Arguments = arguments,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
                WorkingDirectory = Path.Combine(Directory.GetCurrentDirectory(), "..")
            };
            string output, error;
            using (var process = Process.Start(processInfo))
            {
                output = process.StandardOutput.ReadToEnd();
                error = process.StandardError.ReadToEnd();
                process.WaitForExit();

                if (!string.IsNullOrEmpty(error))
                {
                    return $"Error: {error}";
                }
            }
            return output;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult RunLab(int labNumber)
        {
            string output = RunCommand($"msbuild build.proj /t:run /p:lab={labNumber}");
            return Content(output); // Display the result on the page
        }

        [HttpGet]
        public IActionResult BuildLab(int labNumber)
        {
            string output = RunCommand($"msbuild build.proj /t:build /p:lab={labNumber}");
            return Content(output); // Display the result on the page
        }

        [HttpGet]
        public IActionResult TestLab(int labNumber)
        {
            string output = RunCommand($"msbuild build.proj /t:test /p:lab={labNumber}");
            return Content(output); // Display the result on the page
        }
    }
}
