using System;
using System.Collections.Generic;

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

        private Dictionary<string, Action<IEnumerable<string>>> CommandMap { get; }

        /// <summary>
        ///     Starts handling commands
        /// </summary>
        /// <returns>The user's command object</returns>
        public UserCommand ReadCommand()
        {
            try
            {
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
            //  Implement Help command
            throw new NotImplementedException("\nHelp Command not implemented!\n");
        }

        /// <summary>
        ///     Lists all available commands
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private static void ListCommandHandler(IEnumerable<string> parameters)
        {
            //  Implement List command
            throw new NotImplementedException("\nList command not implemented!\n");
        }

        /// <summary>
        ///     Searches the data on the given field for the given query
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private static void SearchByCommandHandler(IEnumerable<string> parameters)
        {
            //  Implement the SearchBy command
            throw new NotImplementedException("\nSearchBy command not implemented!\n");
        }
    }
}