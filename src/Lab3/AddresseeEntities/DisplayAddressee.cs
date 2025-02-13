using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public class DisplayAddressee : IAddressee
{
    private readonly int _importance;
    private DisplayEntities.Display _recipient;

    public DisplayAddressee(DisplayEntities.Display recipient, int importance)
    {
        _recipient = recipient;
        _importance = importance;
    }

    public void ShowMessage(Message? message)
    {
        if (message != null && message.Importance >= _importance) _recipient.GetMessage(message);
    }
}