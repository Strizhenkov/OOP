using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.UserEntities;

public class User : IUser
{
    private Dictionary<int, Message> _receivedMessages;
    public User(int id)
    {
        Id = id;
        _receivedMessages = new Dictionary<int, Message>();
    }

    public int Id { get; set; }
    public void GetMessage(Message? message)
    {
        if (message != null) _receivedMessages.Add(message.Id, message);
    }

    public bool GetMessageStatus(int messageId)
    {
        return _receivedMessages[messageId].IsVisible;
    }

    public bool CheckHaveMessage(int messageId)
    {
        return _receivedMessages.ContainsKey(messageId);
    }

    public string ChangeMessageStatus(int messageId)
    {
        if (_receivedMessages[messageId].IsVisible)
        {
            return "Message has already read";
        }

        _receivedMessages[messageId].IsVisible = true;
        return "Status changed";
    }
}