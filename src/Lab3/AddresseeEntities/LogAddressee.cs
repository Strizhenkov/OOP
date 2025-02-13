using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public class LogAddressee : DecoratorAddressee
{
    public LogAddressee(IAddressee addressee)
        : base(addressee)
    {
        Logs = new Dictionary<int, LogField>();
    }

    public Dictionary<int, LogField> Logs { get; private set; }
    protected override void CreateLog(Message? message)
    {
        if (message != null) Logs.Add(message.Id, new LogField(message));
    }
}