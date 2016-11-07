using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MT.JsonLoader.Core;

namespace MT.JsonLoader
{
    class Program
    {
        static void Main(string[] args)
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
            }
            while (!userCommand.IsExit);
        }
    }
}
