namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface IDimensions
{
    int Length { get; protected set; }
    int Width { get; protected set; }

    public bool Equals(IDimensions? other);
}