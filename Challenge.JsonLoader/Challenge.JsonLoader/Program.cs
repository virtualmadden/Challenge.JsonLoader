using System;
using System.Linq;
using Challenge.JsonLoader.Core;

namespace Challenge.JsonLoader
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //  Sets console title and application message
            Console.Title = Constants.Title;
            Console.WriteLine(Constants.Welcome);

            //  Starts app
            UserCommand userCommand;
            var commandHandler = new CommandHandler();

            string dir = null;

            if (args.Any())
            {
                if (args.Contains("-f"))
                {
                    dir = args.SkipWhile(x => x != "-f").ElementAt(1);
                }
            }

            var people = FileHandler.LoadJsonFiles(dir).ToList();

            do
            {
                userCommand = commandHandler.ReadCommand(people);
            } while (!userCommand.IsExit);
        }
    }
}