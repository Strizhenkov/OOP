using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Disconnect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand
{
    public IDisconnectStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return Strategy != null ? Strategy.Disconnect() : "Wrong Command";
    }
}