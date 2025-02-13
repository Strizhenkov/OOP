using Itmo.ObjectOrientedProgramming.Lab3.Recipient;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntities;

public interface IDisplay : IRecipient
{
    public string LastMessage { get; }
}