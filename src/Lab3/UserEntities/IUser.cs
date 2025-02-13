using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserEntities;

public interface IUser : IRecipient
{
    public bool CheckHaveMessage(int messageId);
    public bool GetMessageStatus(int messageId);
    public string ChangeMessageStatus(int messageId);
}