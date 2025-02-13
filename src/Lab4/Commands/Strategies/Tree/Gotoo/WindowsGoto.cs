using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.Gotoo;

public class WindowsGoto : IGotoStrategy
{
    public string Gotoo(string homePath, string path)
    {
        return Directory.Exists(path) ? "Directory changed" : "Wrong path";
    }
}