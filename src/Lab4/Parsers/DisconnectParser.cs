using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class DisconnectParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }

    public string Execute(IEnumerator<string>? flag)
    {
        return flag == null ? "Null Command" : "Disconnect";
    }
}