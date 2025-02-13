using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;

public abstract class DecoratorAddressee : IAddressee
{
    private readonly IAddressee _addressee;

    protected DecoratorAddressee(IAddressee addressee)
    {
        _addressee = addressee;
    }

    public void ShowMessage(Message message)
    {
        CreateLog(message);
        _addressee.ShowMessage(message);
    }

    protected virtual void CreateLog(Message? message)
    {
    }
}