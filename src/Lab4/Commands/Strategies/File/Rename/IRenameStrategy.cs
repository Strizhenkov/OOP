namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Rename;

public interface IRenameStrategy
{
    public string Rename(string path, string newName);
}