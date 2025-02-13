using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IXmpProfile
{
    IXmpProfile SetTimings(string timings);
    IXmpProfile SetVoltage(string voltage);
    IXmpProfile SetFrequency(string frequency);
}

public class XmpProfile : IXmpProfile
{
    private string? _timings;
    private string? _voltage;
    private string? _frequency;

    public static IXmpProfile Builder(string timings, string voltage, string frequency)
    {
        return new XmpProfile().SetTimings(timings).SetVoltage(voltage).SetFrequency(frequency);
    }

    public IXmpProfile SetTimings(string timings)
    {
        _timings = timings ?? throw new ArgumentNullException(nameof(timings), $"Null timing");
        return this;
    }

    public IXmpProfile SetVoltage(string voltage)
    {
        _voltage = voltage ?? throw new ArgumentNullException(nameof(voltage), $"Null voltage");
        return this;
    }

    public IXmpProfile SetFrequency(string frequency)
    {
        _frequency = frequency ?? throw new ArgumentNullException(nameof(frequency), $"Null frequency");
        return this;
    }
}