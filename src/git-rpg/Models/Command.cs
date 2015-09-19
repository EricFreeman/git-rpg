namespace git_rpg.Models
{
    public class Command
    {
        public string Action { get; set; }
        public string Arguments { get; set; }

        public override string ToString()
        {
            return "git " + Action + " " + Arguments;
        }
    }
}