using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;

public class AllCommandFactory
{
    public ConnectCommandFactory ConnectFactory { get; private set; } = new ConnectCommandFactory();
    public DisconnectCommandFactory DisconnectFactory { get; private set; } = new DisconnectCommandFactory();
    public TreeCommandFactory TreeFactory { get; private set; } = new TreeCommandFactory();
    public FileCommandFactory FileFactory { get; private set; } = new FileCommandFactory();

    public ICommand CreateCommand(string commandName, IEnumerator<string>? commandData)
    {
        return commandName switch
        {
            "Connect" => ConnectFactory.CreateCommand(commandData),
            "Disconnect" => DisconnectFactory.CreateCommand(commandData),
            "Tree" => TreeFactory.CreateCommand(commandData),
            "File" => FileFactory.CreateCommand(commandData),
            _ => new EmptyCommand(),
        };
    }
}