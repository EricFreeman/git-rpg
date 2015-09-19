using System;
using System.Diagnostics;
using System.Linq;

namespace git_rpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            var fileReader = new FileReader();
            var input = fileReader.GetPreviousCommand();

            var commandParser = new CommandParser();
            var command = commandParser.Parse(input);

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(command);

            RunCommand(input);
        }

        private static string ParseCommand(string[] args)
        {
            return args.Aggregate(string.Empty, (accumulator, current) => accumulator + current + " ").Trim();
        }

        private static void RunCommand(string input)
        {
            var startInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + input,
                RedirectStandardError = true,
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };

            var p = Process.Start(startInfo);
            var processOutput = p.StandardOutput.ReadToEnd();
            var processError = p.StandardError.ReadToEnd();
            p.WaitForExit();

            Console.WriteLine(processOutput);
            Console.WriteLine(processError);
        }
    }
}