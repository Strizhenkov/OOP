using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Copy;

public class WindowsCopy : ICopyStrategy
{
    public string Copy(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath) || sourcePath == null) return "Wrong Path";
        string fileDestinationName = destinationPath + "\\" + sourcePath.Split("\\").Last();
        File.Copy(sourcePath, fileDestinationName);
        return "File coped successfully";
    }
}