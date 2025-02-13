using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeCommandParser;

public class ListParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }
    public string Execute(IEnumerator<string>? flag)
    {
        if (flag == null) return "Null Command";
        if (!flag.MoveNext()) return "Empty Depth";
        bool parseResult = int.TryParse(flag.Current, out int result);
        if (!parseResult || result < 0) return "Wrong Depth";
        return "Tree";
    }
}