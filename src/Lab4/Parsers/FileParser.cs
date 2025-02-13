using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers.FileCommandParser;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class FileParser : ICommandParser
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
            "show" => new ShowParser(),
            "move" => new MoveParser(),
            "copy" => new CopyParser(),
            "delete" => new DeleteParser(),
            "rename" => new RenameParser(),
            _ => Successor,
        };
    }
}