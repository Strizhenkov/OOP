namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

public class Disk : IUsingPowerComponent
{
    private int _memorySize;
    private int _speed;

    public int UsedPower { get; private set; }

    public Disk SetMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public Disk SetSpeed(int speed)
    {
        _speed = speed;
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}