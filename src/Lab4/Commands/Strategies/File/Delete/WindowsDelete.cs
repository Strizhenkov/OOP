using System.IO;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Delete;

public class WindowsDelete : IDeleteStrategy
{
    public string Delete(string path)
    {
        if (!File.Exists(path)) return "Wrong path";
        File.Delete(path);
        return "File deleted successfully";
    }
}