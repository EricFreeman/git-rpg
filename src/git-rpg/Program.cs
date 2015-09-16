using System;
using System.Collections.Generic;
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

    public class ModuleRunner
    {
        private readonly List<IModule> _modules;

        public ModuleRunner()
        {
            _modules = new List<IModule>
            {
                new DefaultModule()
            };
        }

        public void Execute(string input)
        {
            _modules.First(x => x.IsMatch(input)).Execute(input);
        }
    }

    public class DefaultModule : IModule
    {
        public bool IsMatch(string input)
        {
            return true;
        }

        public void Execute(string input) { }
    }

    public interface IModule
    {
        bool IsMatch(string input);
        void Execute(string input);
    }
}