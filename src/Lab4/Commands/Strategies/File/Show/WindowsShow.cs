using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Show;

public class WindowsShow : IShowStrategy
{
    public string Show(string path, string mode)
    {
        if (!File.Exists(path)) return "Wrong Path";
        return mode == "console" ? File.ReadAllText(path) : "Wrong Flag";
    }
}