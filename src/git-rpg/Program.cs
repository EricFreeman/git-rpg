using System;
using System.Linq;

namespace git_rpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            var input = ParseCommand(args);

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(input);

            Console.WriteLine(input);
        }

        private static string ParseCommand(string[] args)
        {
            return args.Aggregate(string.Empty, (accumulator, current) => accumulator + current + " ").Trim();
        }
    }
}