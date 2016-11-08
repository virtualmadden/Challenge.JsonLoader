using System;
using System.Collections.Generic;
using System.Linq;
using MT.JsonLoader.Core;
using MT.JsonLoader.Models;

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

            var people = LoadJsonFiles().ToList();

            do
            {
               userCommand = commandHandler.ReadCommand(people);
            } while (!userCommand.IsExit);
        }

        private static IEnumerable<Person> LoadJsonFiles()
        {
            var files = FileHandler.GetFiles(@"..\..\Data");

            var people = new List<Person>();

            foreach (var file in files)
                people.AddRange(FileHandler.LoadFile(file));

            return people;
        }
    }
}