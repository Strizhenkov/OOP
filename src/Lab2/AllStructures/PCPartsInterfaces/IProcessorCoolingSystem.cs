using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IProcessorCoolingSystem : IUsingPowerComponent
{
    IProcessorCoolingSystem SetProcessorCoolingSystemDimensions(int length, int width);
    IProcessorCoolingSystem SetSupportedSocket(string supportedSocket);
    IProcessorCoolingSystem SetMaxTdp(int maxTdp);
    IProcessorCoolingSystem Builder(int length, int width, string supportedSocket, int maxTdp);
}

public class ProcessorCoolingSystem : IProcessorCoolingSystem, ITdp, ISocket
{
    private int _length;
    private int _width;
    public int Tdp { get; set; }
    public string? SocketName { get; set; }
    public int UsedPower { get; private set; }

    public IProcessorCoolingSystem Builder(int length, int width, string supportedSocket, int maxTdp)
    {
        return new ProcessorCoolingSystem().SetProcessorCoolingSystemDimensions(length, width).SetSupportedSocket(supportedSocket)
            .SetMaxTdp(maxTdp);
    }

    public bool Equals(ISocket? other)
    {
        return other != null && SocketName == other.SocketName;
    }

    public bool Equals(ITdp? other)
    {
        return other != null && Tdp > other.Tdp;
    }

    public IProcessorCoolingSystem SetProcessorCoolingSystemDimensions(int length, int width)
    {
        _length = length;
        _width = width;
        return this;
    }

    public IProcessorCoolingSystem SetSupportedSocket(string supportedSocket)
    {
        SocketName = supportedSocket ?? throw new ArgumentNullException(nameof(supportedSocket), $"Null supportedSocket");
        return this;
    }

    public IProcessorCoolingSystem SetMaxTdp(int maxTdp)
    {
        Tdp = maxTdp;
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}