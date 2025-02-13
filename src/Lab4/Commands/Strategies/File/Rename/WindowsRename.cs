using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Rename;

public class WindowsRename : IRenameStrategy
{
    public string Rename(string path, string newName)
    {
        if (!File.Exists(path) || path == null) return "Wrong path";
        string pathWithOutName = string.Join('\\', path.Split('\\').SkipLast(1)) + "\\";
        File.Move(path,  pathWithOutName + newName);
        return "File renamed successfully";
    }
}