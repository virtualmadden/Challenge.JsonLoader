using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace MT.JsonLoader.Core
{
    internal class CommandHandler
    {
        private Dictionary<string, Action<IEnumerable<string>>> commandMap { get; set; }

        public CommandHandler()
        {
            commandMap = new Dictionary<string, Action<IEnumerable<string>>>()
            {
                { Constants.Commands.Exit, x => { } },
                { Constants.Commands.Help, HelpCommandHandler },
                { Constants.Commands.List, ListCommandHandler },
                { Constants.Commands.SearchBy, SearchByCommandHandler }
                //  Add any additional commands here
            };
        }

        /// <summary>
        /// Starts handling commands
        /// </summary>
        /// <returns>The user's command object</returns>
        public UserCommand ReadCommand()
        {
            try
            {
                var userCommand = UserCommand.GetCommands();

                if (!string.IsNullOrWhiteSpace(userCommand.Command))
                    commandMap[userCommand.Command](userCommand.Parameters);
                
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
        /// Displays the available methods
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private void HelpCommandHandler(IEnumerable<string> parameters)
        {
            //  Implement Help command
            throw new NotImplementedException("\nHelp Command not implemented!\n");
        }

        /// <summary>
        /// Lists all available commands
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private void ListCommandHandler(IEnumerable<string> parameters)
        {
            //  Implement List command
            throw new NotImplementedException("\nList command not implemented!\n");
        }

        /// <summary>
        /// Searches the data on the given field for the given query
        /// </summary>
        /// <param name="parameters">Additional command parameters</param>
        /// <returns></returns>
        private void SearchByCommandHandler(IEnumerable<string> parameters)
        {
            //  Implement the SearchBy command
            throw new NotImplementedException("\nSearchBy command not implemented!\n");
        }        
    }
}
