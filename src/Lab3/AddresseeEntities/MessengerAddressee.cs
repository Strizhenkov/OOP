using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public class MessengerAddressee : IAddressee
{
    private readonly int _importance;
    private Messenger _recipient;

    public MessengerAddressee(Messenger recipient, int importance)
    {
        _recipient = recipient;
        _importance = importance;
    }

    public void ShowMessage(Message? message)
    {
        if (message != null && message.Importance >= _importance) _recipient.GetMessage(message);
    }
}