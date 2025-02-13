using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Connect;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ConnectCommand : ICommand
{
    public ConnectCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        HomePath = flag?.Current;
        flag?.MoveNext();
        Mode = flag?.Current;
    }

    public string? HomePath { get; private set; }
    public string? Mode { get; private set; }
    public IConnectStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return HomePath != null && Mode != null && Strategy != null ? Strategy.Connect(HomePath, Mode) : "Wrong Mode or Path";
    }
}