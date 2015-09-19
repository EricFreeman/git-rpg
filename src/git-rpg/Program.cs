namespace git_rpg
{
    public class Program
    {
        static void Main(string[] args)
        {
            var commandParser = new CommandParser();
            var command = commandParser.Parse(args);

            var moduleRunner = new ModuleRunner();
            moduleRunner.Execute(command);

            var commandRunner = new CommandRunner();
            commandRunner.Execute(command);
        }       
    }
}