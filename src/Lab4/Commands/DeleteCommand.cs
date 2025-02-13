using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Delete;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DeleteCommand : ICommand
{
    public DeleteCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        Path = flag?.Current;
    }

    public string? Path { get; set; }
    public IDeleteStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return Path != null && Strategy != null ? Strategy.Delete(Path) : "Wrong Path";
    }
}