using System;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public class LogField
{
    public LogField(Message? message)
    {
        Time = DateTime.Now;
        if (message != null) LogMessage = message.ToString();
    }

    public DateTime Time { get; set; }
    public string? LogMessage { get; set; }
}