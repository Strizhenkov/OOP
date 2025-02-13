using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParser;

public class DeleteParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }
    public string Execute(IEnumerator<string>? flag)
    {
        if (flag == null) return "Null Command";
        return !flag.MoveNext() ? "Empty Path" : "File";
    }
}