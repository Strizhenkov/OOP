namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Move;

public interface IMoveStrategy
{
    public string Move(string sourcePath, string destinationPath);
}