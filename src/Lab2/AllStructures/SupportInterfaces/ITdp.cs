namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface ITdp
{
    int Tdp { get; protected set; }

    public bool Equals(ITdp other);
}