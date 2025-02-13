using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeCommandParser;

public class GotoParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }
    public string Execute(IEnumerator<string>? flag)
    {
        if (flag == null) return "Null Command";
        return !flag.MoveNext() ? "Empty Path" : "Tree";
    }
}