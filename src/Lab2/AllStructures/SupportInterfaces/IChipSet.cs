namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface IChipSet
{
    int MinChipSet { get; protected set; }
    int MaxChipSet { get; protected set; }

    public bool Equals(IChipSet? other);
}