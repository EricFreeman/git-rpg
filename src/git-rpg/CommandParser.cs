using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using git_rpg.Models;

namespace git_rpg
{
    public class CommandParser
    {
        public Command Parse()
        {
            var args = RemoveExtraCommands();

            return new Command
            {
                Action = args[0],
                Arguments = string.Join(" ", args.GetRange(1, args.Count - 1))
            };
        }

        private List<string> RemoveExtraCommands()
        {
            var argsNoExecutable =
                Regex.Replace(Environment.CommandLine, "(\"?.*\\.exe\"?\\s)", string.Empty)
                     .Split(' ');

            var temporaryList = argsNoExecutable.ToList();
            temporaryList.RemoveAt(0); // remove executable location
            var commandsToRemove = new List<string> { "git", "rpg", "git-rpg" };
            commandsToRemove.ForEach(x => temporaryList.Remove(x));

            return temporaryList;
        }
    }
}