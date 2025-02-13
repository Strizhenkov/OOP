using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.MessengerEntities;

public class Messenger : IMessenger
{
    public Messenger(int id)
    {
        Id = id;
        MessageList = new List<string>();
    }

    public int Id { get; set; }
    public IList<string> MessageList { get; set; }

    public void GetMessage(Message? message)
    {
        MessageList.Add(message != null ? message.ToString() + " From Messenger" : "Empty Message");
    }

    public void Print()
    {
        foreach (string currentMessage in MessageList)
        {
            Console.WriteLine(currentMessage);
        }
    }
}