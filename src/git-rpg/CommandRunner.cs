using System;
using System.Diagnostics;
using git_rpg.Models;

namespace git_rpg
{
    public class CommandRunner
    {
        public void Execute(Command command)
        {
            var startInfo = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/C " + command,
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