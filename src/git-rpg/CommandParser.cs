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

            var input = args
                .Select(x => $"\"{x}\"")
                .Aggregate(string.Empty, (accumulator, current) => accumulator + current + " ")
                .Trim();

            var commandParts = input.Split(' ').ToList();

            return new Command
            {
                Action = commandParts[0],
                Arguments = string.Join(" ", commandParts.GetRange(1, commandParts.Count - 1))
            };
        }

        private string[] RemoveExtraCommands()
        {
            var argsNoExecutable =
                Regex.Replace(Environment.CommandLine, "(\"?.*\\.exe\"?\\s)", string.Empty)
                     .Split(' ');

            var temporaryList = argsNoExecutable.ToList();
            temporaryList.RemoveAt(0); // remove executable location
            var commandsToRemove = new List<string> { "git", "rpg", "git-rpg" };
            commandsToRemove.ForEach(x => temporaryList.Remove(x));

            return temporaryList.ToArray();
        }
    }
}