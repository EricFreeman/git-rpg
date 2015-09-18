using System.Linq;
using git_rpg.Models;

namespace git_rpg
{
    public class CommandParser
    {
        public Command Parse(string input)
        {
            var commandParts = input.Split(' ').ToList();

            return new Command
            {
                Action = commandParts[0],
                Arguments = string.Join(" ", commandParts.GetRange(1, commandParts.Count - 1))
            };
        }
    }
}