using System;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntities;

public interface IDisplayDriver
{
    void Print(string lastMessage);

    void SetColor(ConsoleColor color);

    void Clear();
}