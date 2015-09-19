using git_rpg.Models;

namespace git_rpg.Modules
{
    public interface IModule
    {
        bool IsMatch(Command command);
        void Execute(Command command);
    }
}