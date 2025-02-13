using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Rename;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class RenameCommand : ICommand
{
    public RenameCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        Path = flag?.Current;
        flag?.MoveNext();
        NewName = flag?.Current;
    }

    public string? Path { get; set; }
    public string? NewName { get; set; }
    public IRenameStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return NewName != null && Path != null && Strategy != null ? Strategy.Rename(Path, NewName) : "Wrong Path or Name";
    }
}