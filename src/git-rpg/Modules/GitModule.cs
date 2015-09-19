using System;
using System.IO;
using System.Linq;
using System.Reflection;
using git_rpg.Models;

namespace git_rpg.Modules
{
    class GitModule : IModule
    {
        public bool IsMatch(Command command)
        {
            var dictionaryLocation = Assembly.GetEntryAssembly().Location;
            var commands = File.ReadAllLines(dictionaryLocation.Replace("git-rpg.exe", "git dictionary.txt"));

            return commands.Contains(command.Action);
        }

        public void Execute(Command command)
        {
            Console.WriteLine("Earned 10 XP!");
        }
    }
}