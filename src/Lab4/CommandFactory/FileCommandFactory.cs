using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;

public class FileCommandFactory : Factory
{
    public override ICommand CreateCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        return flag?.Current switch
        {
            "show" => new ShowCommand(flag),
            "move" => new MoveCommand(flag),
            "copy" => new CopyCommand(flag),
            "delete" => new DeleteCommand(flag),
            "rename" => new RenameCommand(flag),
            _ => new EmptyCommand(),
        };
    }
}