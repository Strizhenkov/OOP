namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public interface IUsingPowerComponent
{
    public int UsedPower { get; }
    IUsingPowerComponent SetUsedPower(int usedPower);
}