namespace git_rpg.Modules
{
    public class DefaultModule : IModule
    {
        public bool IsMatch(string input)
        {
            return true;
        }

        public void Execute(string input) { }
    }
}