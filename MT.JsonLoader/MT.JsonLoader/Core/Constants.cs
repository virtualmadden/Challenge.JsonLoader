namespace MT.JsonLoader.Core
{
    public static class Constants
    {
        public const string Prompt = ">";
        public const string TypeHelp = "Type 'help' to see a list of available commands.";

        public static readonly string[] CommandList =
        {
            $"{Commands.Exit} - exits the application",
            $"{Commands.Help} - displays these commands",
            $"{Commands.List} - lists the data",
            $"{Commands.SearchBy} <field> <query> - searches the field for the given query"
        };

        public static readonly string InvalidCommand = $"\nAn invalid command was entered.\n{TypeHelp}\n";
        public static readonly string Title = "Metal Toad Json Parser";
        public static readonly string Welcome = $"Welcome to the Metal Toad Json Parsing application.\n{TypeHelp}\n";

        public static class Commands
        {
            public static readonly string Exit = "exit";
            public static readonly string Help = "help";
            public static readonly string List = "list";
            public static readonly string SearchBy = "searchby";

            //  Add any additional command strings here
        }
    }
}