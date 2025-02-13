using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.List;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ListCommand : ICommand
{
    public ListCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        bool result = int.TryParse(flag?.Current, out int depth);
        if (result) Depth = depth;
    }

    public int Depth { get; private set; }
    public IListStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return Strategy != null ? Strategy.List(homePath, Depth) : "Wrong Command";
    }
}