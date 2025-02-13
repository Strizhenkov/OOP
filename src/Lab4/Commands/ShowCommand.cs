using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Show;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ShowCommand : ICommand
{
    public ShowCommand(IEnumerator<string>? flag)
    {
        flag?.MoveNext();
        Path = flag?.Current;
        flag?.MoveNext();
        Mode = flag?.Current;
    }

    public string? Path { get; set; }
    public string? Mode { get; set; }
    public IShowStrategy? Strategy { get; set; }
    public string Execute(string homePath)
    {
        return Path != null && Mode != null && Strategy != null ? Strategy.Show(Path, Mode) : "Wrong Path or Mode";
    }
}