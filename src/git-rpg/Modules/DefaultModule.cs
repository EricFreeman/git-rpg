using System;
using git_rpg.Models;

namespace git_rpg.Modules
{
    public class DefaultModule : IModule
    {
        public bool IsMatch(Command command)
        {
            return true;
        }

        public void Execute(Command command)
        {
            Console.WriteLine("I'm not quite sure what you meant by that.");
        }
    }
}