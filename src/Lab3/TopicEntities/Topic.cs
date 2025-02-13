using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab3.AddresseeEntities;
using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.TopicEntities;

public class Topic : ITopic
{
    private string _name;
    private IList<IAddressee> _addressee;

    public Topic(string name, IList<IAddressee> addressee)
    {
        _name = name;
        _addressee = addressee;
    }

    public void SentMessage(Message message)
    {
        foreach (IAddressee currentAddressee in _addressee)
        {
            currentAddressee.ShowMessage(message);
        }
    }
}