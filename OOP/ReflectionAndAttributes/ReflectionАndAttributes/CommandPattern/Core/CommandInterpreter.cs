using System.Reflection;
using CommandPattern.Core.Commands;
using CommandPattern.Core.Contracts;

namespace CommandPattern.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        public string Read(string args)
        {
            string[] details = args.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            ICommand command = null;

            Type commandType = Assembly
                .GetEntryAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == $"{details[0]}Command");

            if (commandType == null)
            {
                throw new InvalidOperationException("Command not found");
            }

            ICommand commandInstance  = Activator.CreateInstance(commandType) as ICommand;

            return commandInstance.Execute(details.Skip(1).ToArray());
        }
    }
}
