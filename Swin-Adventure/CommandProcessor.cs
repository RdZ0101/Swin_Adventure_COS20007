using Swin_Adventure;
using System.Collections.Generic;
using System.Linq;

public class CommandProcessor
{
    private readonly List<Command> _commands;

    public CommandProcessor()
    {
        _commands = new List<Command>();
    }

    public void AddCommand(Command command)
    {
        _commands.Add(command);
    }

    public string ProcessCommand(Player player, string[] commandWords)
    {
        string firstWord = commandWords[0].ToLower(); // Convert to lowercase for case insensitivity

        // Find the corresponding command based on the first word
        Command command = _commands.FirstOrDefault(cmd => cmd.AreYou(firstWord));

        if (command != null)
        {
            // Execute the found command
            return command.Execute(player, commandWords);
        }
        else
        {
            return "I don't understand what you're trying to do.";
        }
    }

}
