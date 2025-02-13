namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Copy;

public interface ICopyStrategy
{
    public string Copy(string sourcePath, string destinationPath);
}