using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.Recipient;

public interface IRecipient
{
    protected int Id { get; }

    public void GetMessage(Message? message);
}