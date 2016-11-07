using System;
using MT.JsonLoader.Core;

namespace MT.JsonLoader
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
            do
            {
                userCommand = commandHandler.ReadCommand();
            } while (!userCommand.IsExit);
        }
    }
}