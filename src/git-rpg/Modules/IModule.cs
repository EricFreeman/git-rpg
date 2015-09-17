namespace git_rpg.Modules
{
    public interface IModule
    {
        bool IsMatch(string input);
        void Execute(string input);
    }
}