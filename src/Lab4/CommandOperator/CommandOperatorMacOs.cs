using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandOperator;

public class CommandOperatorMacOs : ICommandOperator
{
    public string HomePath { get; private set; } = string.Empty;

    public string CommandRun(ICommand command)
    {
        throw new System.NotImplementedException();
    }
}