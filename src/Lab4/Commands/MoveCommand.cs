using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Move;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveCommand : ICommand
{
    public MoveCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        SourcePath = flag?.Current;
        flag?.MoveNext();
        DestinationPath = flag?.Current;
    }

    public string? SourcePath { get; set; }
    public string? DestinationPath { get; set; }
    public IMoveStrategy? Strategy { get; set; }

    public string Execute(string homePath)
    {
        return SourcePath != null && DestinationPath != null && Strategy != null
            ? Strategy.Move(SourcePath, DestinationPath)
            : "Wrong Path";
    }
}