using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParser;

public class CopyParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }
    public string Execute(IEnumerator<string>? flag)
    {
        if (flag == null) return "Null Command";
        if (!flag.MoveNext()) return "Empty Source Path";
        return !flag.MoveNext() ? "Empty Destination Path" : "File";
    }
}