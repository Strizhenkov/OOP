using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;

public class TreeCommandFactory : Factory
{
    public override ICommand CreateCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        return flag?.Current switch
        {
            "goto" => new GotoCommand(flag),
            "list" => new ListCommand(flag),
            _ => new EmptyCommand(),
        };
    }
}