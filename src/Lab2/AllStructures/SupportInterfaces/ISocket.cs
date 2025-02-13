namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface ISocket
{
    string? SocketName { get; protected set; }

    public bool Equals(ISocket? other);
}