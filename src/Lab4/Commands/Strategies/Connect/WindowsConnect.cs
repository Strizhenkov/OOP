using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Connect;

public class WindowsConnect : IConnectStrategy
{
    public string Connect(string homePath, string mode)
    {
        if (mode != "local")
            return "Wrong Mode";
        return !Directory.Exists(homePath) ? "Wrong Path" : "Connect";
    }
}