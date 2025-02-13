using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public class SsdDrive : Disk
{
    private string? _typeConnection;
    public bool BuildStatus { get; private set; }

    public SsdDrive Builder(string typeConnection, int memorySize, int speed, int usedPower)
    {
        BuildStatus = true;
        return (SsdDrive)new SsdDrive().SetTypeConnection(typeConnection).SetMemorySize(memorySize).SetSpeed(speed)
            .SetUsedPower(usedPower);
    }

    public Disk SetTypeConnection(string typeConnection)
    {
        _typeConnection = typeConnection ??
                          throw new ArgumentNullException(nameof(typeConnection), $"Null typeConnection");
        return this;
    }
}