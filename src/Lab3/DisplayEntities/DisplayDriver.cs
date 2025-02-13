using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntities;

public class DisplayDriver : IDisplayDriver
{
    public void Print(string lastMessage)
    {
        Console.WriteLine(lastMessage);
    }

    public void SetColor(ConsoleColor color)
    {
        Console.ForegroundColor = color;
    }

    public void Clear()
    {
        Console.Clear();
    }
}