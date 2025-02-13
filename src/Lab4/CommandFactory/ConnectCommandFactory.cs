using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;

public class ConnectCommandFactory : Factory
{
    public override ICommand CreateCommand(IEnumerator<string>? flag)
    {
        return new ConnectCommand(flag);
    }
}