using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.Parsers;

public class TypeCommandParser
{
    public ICommandParser? Successor { get; private set; }
    public IList<string>? CommandData { get; private set; }
    public AllCommandFactory Factory { get; private set; } = new AllCommandFactory();

    public ICommand Execute(string? input)
    {
        if (input == null) return new EmptyCommand();

        CommandData = input.Split(' ').ToList();
        using IEnumerator<string> iterator = CommandData.GetEnumerator();

        iterator.MoveNext();
        SetSuccessor(iterator.Current);

        if (Successor == null) return new EmptyCommand();
        string name = Successor.Execute(iterator);
        iterator.Reset();
        iterator.MoveNext();
        return Factory.CreateCommand(name, iterator);
    }

    private void SetSuccessor(string input)
    {
        Successor = input switch
        {
            "connect" => new ConnectParser(),
            "disconnect" => new DisconnectParser(),
            "tree" => new TreeParser(),
            "file" => new FileParser(),
            _ => Successor,
        };
    }
}