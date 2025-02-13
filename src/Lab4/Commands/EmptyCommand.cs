namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class EmptyCommand : ICommand
{
    public string Execute(string homePath)
    {
        return "Empty Command";
    }
}