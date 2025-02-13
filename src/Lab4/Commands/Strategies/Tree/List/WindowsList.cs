using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.List;

public class WindowsList : IListStrategy
{
    public string List(string homePath, int depth)
    {
        return homePath != null ? GetFilesFromDeep(homePath, depth, homePath.Split("\\").Last() + '\n', "--") : "Wrong Path";
    }

    private static string GetFilesFromDeep(string dirPath, int deep, string currentAnswer, string step)
    {
        if (deep == 0)
        {
            IEnumerable<string> currentDirEnumerable = Directory.EnumerateFiles(dirPath);
            foreach (string file in currentDirEnumerable)
            {
                currentAnswer += step + file.Split('\\').Last() + '\n';
            }

            currentDirEnumerable = Directory.EnumerateDirectories(dirPath);
            foreach (string newDirPath in currentDirEnumerable)
            {
                currentAnswer += step + newDirPath.Split("\\").Last() + '\n';
            }

            return currentAnswer;
        }
        else
        {
            IEnumerable<string> currentDirEnumerable = Directory.EnumerateFiles(dirPath);
            foreach (string file in currentDirEnumerable)
            {
                currentAnswer += step + file.Split('\\').Last() + '\n';
            }

            currentDirEnumerable = Directory.EnumerateDirectories(dirPath);
            foreach (string newDirPath in currentDirEnumerable)
            {
                currentAnswer += step + GetFilesFromDeep(newDirPath, deep - 1, newDirPath.Split("\\").Last() + '\n', step + "--");
            }

            return currentAnswer;
        }
    }
}