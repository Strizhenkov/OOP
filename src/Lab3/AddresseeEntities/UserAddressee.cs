using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab3.UserEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public class UserAddressee : IAddressee
{
    private readonly int _importance;
    private User _recipient;

    public UserAddressee(User recipient, int importance)
    {
        _recipient = recipient;
        _importance = importance;
    }

    public void ShowMessage(Message? message)
    {
        if (message != null && message.Importance >= _importance) _recipient.GetMessage(message);
    }
}