using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.Gotoo;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : ICommand
{
    public GotoCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        Path = flag?.Current;
    }

    public string? Path { get;  set; }
    public IGotoStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return Path != null && Strategy != null ? Strategy.Gotoo(homePath, Path) : "Wrong path";
    }
}