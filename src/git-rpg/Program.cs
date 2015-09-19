using System;
using System.Linq;

namespace git_rpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = ParseCommand(args);

            var commandParser = new CommandParser();
            var command = commandParser.Parse(input);

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(command);

            Console.WriteLine(input);
        }

        private static string ParseCommand(string[] args)
        {
            return args.Aggregate(string.Empty, (accumulator, current) => accumulator + current + " ").Trim();
        }
    }
}