using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerEntities;

public interface IMessenger : IRecipient
{
    public IList<string> MessageList { get; }
    void Print();
}