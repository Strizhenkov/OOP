using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.TreeCommandParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class TreeParser : ICommandParser
{
    public ICommandParser? Successor { get; set; }

    public string Execute(IEnumerator<string>? flag)
    {
        if (flag == null) return "Null Command";
        flag.MoveNext();
        SetSuccessor(flag.Current);
        return Successor != null ? Successor.Execute(flag) : "Wrong Command";
    }

    private void SetSuccessor(string input)
    {
        Successor = input switch
        {
            "goto" => new GotoParser(),
            "list" => new ListParser(),
            _ => Successor,
        };
    }
}