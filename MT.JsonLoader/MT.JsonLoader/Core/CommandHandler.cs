using System;
using System.Collections.Generic;
using System.Linq;
using MT.JsonLoader.Models;

namespace MT.JsonLoader.Core
{
    internal class CommandHandler
    {
        public CommandHandler()
        {
            CommandMap = new Dictionary<string, Action<IEnumerable<string>>>
            {
                {Constants.Commands.Exit, x => { }},
                {Constants.Commands.Help, HelpCommandHandler},
                {Constants.Commands.List, ListCommandHandler},
                {Constants.Commands.SearchBy, SearchByCommandHandler}
                //  Add any additional commands here
            };
        }

        private List<Person> People { get; set; }

        private Dictionary<string, Action<IEnumerable<string>>> CommandMap { get; }

        /// <summary>
        ///     Starts handling commands
        /// </summary>
        /// <returns>The user's command object</returns>
        public UserCommand ReadCommand(IEnumerable<Person> people)
        {
            try
            {
                People = people.ToList();

                var userCommand = UserCommand.GetCommands();

                if (!string.IsNullOrWhiteSpace(userCommand.Command))
                    CommandMap[userCommand.Command](userCommand.Parameters);

                return userCommand;
            }
            catch (NotImplementedException notImplementedError)
            {
                Console.WriteLine(notImplementedError.Message);
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine(Constants.InvalidCommand);
            }

            return new UserCommand();
        }

        /// <summary>
        ///     Displays the available methods
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private static void HelpCommandHandler(IEnumerable<string> parameters)
        {
            Console.WriteLine(Constants.HelpCommand);
        }

        /// <summary>
        ///     Lists all available commands
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private void ListCommandHandler(IEnumerable<string> parameters)
        {
            if (parameters.Any())
            {
                var people = People.Where(x => x.SourceFile.Equals(parameters.First())).ToList();

                if (parameters.First().Equals("peopleRpg.json", StringComparison.InvariantCultureIgnoreCase))
                    foreach (var person in people)
                        Console.WriteLine(
                            $"{person.Id} - {person.FirstName} - {person.LastName} - {person.CharacterRace} - {person.CharacterClass}");
                else if (parameters.First().Equals("peopleWithFollowers.json", StringComparison.InvariantCultureIgnoreCase))
                    foreach (var person in people)
                        Console.WriteLine(
                            $"{person.Id} - {person.FirstName} - {person.LastName} - {person.Email} - {person.FollowerCount}");
            }
            else
            {
                foreach (var person in People)
                    Console.WriteLine(
                        $"{person.Id} - {person.FirstName} - {person.LastName} - {person.Email} - {person.CharacterRace} - {person.CharacterClass} - {person.FollowerCount}");
            }
        }

        /// <summary>
        ///     Searches the data on the given field for the given query
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private void SearchByCommandHandler(IEnumerable<string> parameters)
        {
            var people = new List<Person>();

            var searchTerm = parameters.Skip(1).First();

            switch (parameters.First())
            {
                case "Id":
                    people.AddRange(People.Where(x => x.Id.ToString().Equals(searchTerm)));
                    break;
                case "FirstName":
                    people.AddRange(People.Where(x => x.FirstName.Contains(searchTerm)));
                    break;
                case "LastName":
                    people.AddRange(People.Where(x => x.LastName.Contains(searchTerm)));
                    break;
                case "Email":
                    people.AddRange(People.Where(x => x.Email.Contains(searchTerm)));
                    break;
                case "CharacterRace":
                    people.AddRange(People.Where(x => x.CharacterRace.Contains(searchTerm)));
                    break;
                case "CharacterClass":
                    people.AddRange(People.Where(x => x.CharacterClass.Contains(searchTerm)));
                    break;
                case "Followers":
                    people.AddRange(People.Where(x => x.FollowerCount.Equals(Convert.ToInt32(searchTerm))));
                    break;
            }

            foreach (var person in people)
                Console.WriteLine(
                    $"{person.Id} - {person.FirstName} - {person.LastName} - {person.Email} - {person.CharacterRace} - {person.CharacterClass} - {person.FollowerCount}");
        }
    }
}