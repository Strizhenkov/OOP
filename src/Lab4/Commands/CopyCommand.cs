using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Copy;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CopyCommand : ICommand
{
    public CopyCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        SourcePath = flag?.Current;
        flag?.MoveNext();
        DestinationPath = flag?.Current;
    }

    public string? SourcePath { get; set; }
    public string? DestinationPath { get; set; }
    public ICopyStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return SourcePath != null && DestinationPath != null && Strategy != null
            ? Strategy.Copy(SourcePath, DestinationPath)
            : "Wrong Path";
    }
}