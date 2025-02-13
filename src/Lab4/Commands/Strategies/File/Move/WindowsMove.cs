using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Move;

public class WindowsMove : IMoveStrategy
{
    public string Move(string sourcePath, string destinationPath)
    {
        if (!File.Exists(sourcePath) || sourcePath == null) return "Wrong path";
        string fileDestinationName = destinationPath + "\\" + sourcePath.Split("\\").Last();
        File.Move(sourcePath, fileDestinationName);
        return "File moved successfully";
    }
}