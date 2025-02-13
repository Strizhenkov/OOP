using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public interface ICommandParser
{
    public ICommandParser? Successor { get; set; }
    public string Execute(IEnumerator<string>? flag);
}