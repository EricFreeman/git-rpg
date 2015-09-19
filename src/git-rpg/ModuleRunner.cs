using System.Collections.Generic;
using System.Linq;
using git_rpg.Models;
using git_rpg.Modules;

namespace git_rpg
{
    public class ModuleRunner
    {
        private readonly List<IModule> _modules;

        public ModuleRunner()
        {
            _modules = new List<IModule>
            {
                new GitModule(),
                new DefaultModule()
            };
        }

        public void Execute(Command command)
        {
            _modules.First(x => x.IsMatch(command)).Execute(command);
        }
    }
}