using git_rpg.Models;

namespace git_rpg.Modules
{
    public class DefaultModule : IModule
    {
        public bool IsMatch(Command input)
        {
            return true;
        }

        public void Execute(Command input) { }
    }
}