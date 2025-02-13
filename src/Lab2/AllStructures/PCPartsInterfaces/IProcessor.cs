using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IProcessor : IUsingPowerComponent
{
    IProcessor SetCoreFrequency(int coreFrequency);

    IProcessor SetCoreNumber(int coreNumber);

    IProcessor SetVideoCore(bool videoCore);

    IProcessor SetSocket(string socketName);

    IProcessor SetSupportedMemoryFrequency(int chipSet);
    IProcessor SetTdp(int tdp);

    IProcessor Builder(int coreFrequency, int coreNumber, string socketName, bool videoCore, int chipSet, int tdp, int usedPower);
}

public class Processor : IProcessor, ISocket, IVideoCore, ITdp, IChipSet
{
    private int _coreFrequency;
    private int _coreNumber;

    public string? SocketName { get; set; }
    public int UsedPower { get; private set; }
    public int Tdp { get; set; }
    public bool VideoCore { get; set; }
    public int MinChipSet { get; set; }
    public int MaxChipSet { get; set; }

    public IProcessor Builder(int coreFrequency, int coreNumber, string socketName, bool videoCore, int chipSet, int tdp, int usedPower)
    {
        return (IProcessor)new Processor().SetCoreFrequency(coreFrequency).SetCoreNumber(coreNumber).SetSocket(socketName)
            .SetVideoCore(videoCore).SetSupportedMemoryFrequency(chipSet).SetTdp(tdp).SetUsedPower(usedPower);
    }

    public bool Equals(IChipSet? other)
    {
        return other != null && (MaxChipSet <= other.MaxChipSet && other.MinChipSet >= MinChipSet);
    }

    public bool Equals(ITdp? other)
    {
        return other != null && Tdp < other.Tdp;
    }

    public bool Equals(ISocket? other)
    {
        return other != null && SocketName == other.SocketName;
    }

    public bool Equals(IVideoCore? other)
    {
        return other != null && (VideoCore || other.VideoCore);
    }

    public IProcessor SetCoreFrequency(int coreFrequency)
    {
        _coreFrequency = coreFrequency;
        return this;
    }

    public IProcessor SetCoreNumber(int coreNumber)
    {
        _coreNumber = coreNumber;
        return this;
    }

    public IProcessor SetSocket(string socketName)
    {
        SocketName = socketName;
        return this;
    }

    public IProcessor SetVideoCore(bool videoCore)
    {
        VideoCore = videoCore;
        return this;
    }

    public IProcessor SetSupportedMemoryFrequency(int chipSet)
    {
        MinChipSet = chipSet;
        MaxChipSet = chipSet;
        return this;
    }

    public IProcessor SetTdp(int tdp)
    {
        Tdp = tdp;
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}