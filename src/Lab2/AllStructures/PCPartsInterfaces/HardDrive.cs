using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public class HardDrive : Disk
{
    public bool BuildStatus { get; private set; }

    public HardDrive Builder(int memorySize, int speed, int usedPower)
    {
        BuildStatus = true;
        return (HardDrive)new HardDrive().SetMemorySize(memorySize).SetSpeed(speed).SetUsedPower(usedPower);
    }
}