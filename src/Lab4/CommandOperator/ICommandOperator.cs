using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandOperator;

public interface ICommandOperator
{
    public string CommandRun(ICommand command);
}