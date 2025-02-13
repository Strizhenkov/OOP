namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface IVideoCore
{
    bool VideoCore { get; protected set; }

    public bool Equals(IVideoCore? other);
}