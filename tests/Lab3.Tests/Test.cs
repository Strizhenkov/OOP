using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;
using Itmo.ObjectOrientedProgramming.Lab3.MessengerEntities;
using Itmo.ObjectOrientedProgramming.Lab3.TopicEntities;
using Itmo.ObjectOrientedProgramming.Lab3.UserEntities;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab3.Tests;

public class Test
{
    [Fact]
    public void TestGetNotReadMessage()
    {
        var firstUser = new User(1);
        var addressee = new UserAddressee(firstUser, 10);
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        topic.SentMessage(new Message(1, "Hello", "World", 100));

        Assert.True(firstUser.CheckHaveMessage(1));
    }

    [Fact]
    public void TestChangeMessageStatus()
    {
        var firstUser = new User(1);
        var addressee = new UserAddressee(firstUser, 10);
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        topic.SentMessage(new Message(1, "Hello", "World", 100));

        Assert.Equal("Status changed", firstUser.ChangeMessageStatus(1));
        Assert.True(firstUser.GetMessageStatus(1));
    }

    [Fact]
    public void TestChangeChangedMessageStatus()
    {
        var firstUser = new User(1);
        var addressee = new UserAddressee(firstUser, 10);
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        topic.SentMessage(new Message(1, "Hello", "World", 100));

        Assert.Equal("Status changed", firstUser.ChangeMessageStatus(1));
        Assert.Equal("Message has already read", firstUser.ChangeMessageStatus(1));
    }

    [Fact]
    public void TestCheckFilter()
    {
        var firstUser = new User(1);
        var addressee = new UserAddressee(firstUser, 50);
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        var lines = new List<List<string>>();
        using (var reader = new
                   StreamReader(@"..\..\..\Moka.txt"))
        {
            string line;
            try
            {
                while ((line = reader.ReadLine() ?? throw new InvalidOperationException()) != null)
                {
                    lines.Add(line.Split('\t').ToList());
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        foreach (List<string> message in lines)
        {
            bool idResult = int.TryParse(message[0], out int id);
            bool importanceResult = int.TryParse(message[3], out int importance);
            if (idResult && importanceResult)
                topic.SentMessage(new Message(id, message[1], message[2], importance));
        }

        Assert.True(!firstUser.CheckHaveMessage(4));
    }

    [Fact]
    public void TestCheckLog()
    {
        var firstUser = new User(1);
        var addressee = new LogAddressee(new UserAddressee(firstUser, 10));
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        var lines = new List<List<string>>();
        using (var reader = new
                   StreamReader(@"..\..\..\Moka.txt"))
        {
            string line;
            try
            {
                while ((line = reader.ReadLine() ?? throw new InvalidOperationException()) != null)
                {
                    lines.Add(line.Split('\t').ToList());
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        foreach (List<string> message in lines)
        {
            bool idResult = int.TryParse(message[0], out int id);
            bool importanceResult = int.TryParse(message[3], out int importance);
            if (idResult && importanceResult)
                topic.SentMessage(new Message(id, message[1], message[2], importance));
        }

        Assert.Equal(DateTime.Now.ToLongTimeString(), addressee.Logs[6].Time.ToLongTimeString());
    }

    [Fact]
    public void TestMessage()
    {
        var contact = new Messenger(1);
        var addressee = new MessengerAddressee(contact, 10);
        var topic = new Topic("Fishing", new List<IAddressee>() { addressee });

        var lines = new List<List<string>>();
        using (var reader = new
                   StreamReader(@"..\..\..\Moka.txt"))
        {
            string line;
            try
            {
                while ((line = reader.ReadLine() ?? throw new InvalidOperationException()) != null)
                {
                    lines.Add(line.Split('\t').ToList());
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e);
            }
        }

        foreach (List<string> message in lines)
        {
            bool idResult = int.TryParse(message[0], out int id);
            bool importanceResult = int.TryParse(message[3], out int importance);
            if (idResult && importanceResult)
                topic.SentMessage(new Message(id, message[1], message[2], importance));
        }

        Assert.Equal("Honorable \n \"Proin eu mi. Nulla ac enim. In tempor, turpis nec euismod scelerisque, quam turpis adipiscing lorem, vitae mattis nibh ligula nec sem.Duis aliquam convallis nunc. Proin at turpis a pede posuere nonummy. Integer non velit.Donec diam neque, vestibulum eget, vulputate ut, ultrices vel, augue. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Donec pharetra, magna vestibulum aliquet ultrices, erat tortor sollicitudin mi, sit amet lobortis sapien sapien non mi. Integer ac neque.\" \n From Messenger", contact.MessageList.Last());
    }
}