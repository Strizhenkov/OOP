using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandFactory;

public abstract class Factory
{
    public abstract ICommand CreateCommand(IEnumerator<string>? flag);
}