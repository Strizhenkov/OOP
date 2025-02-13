using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IRam : IUsingPowerComponent
{
    IRam SetMemorySize(int memorySize);
    IRam SetFrequency(int frequency);
    IRam SetAccessXmpProfile(string accessXmpProfile);
    IRam SetFormFactor(string formFactor);
    IRam SetVersionDdr(string versionDdr);

    IRam Builder(int memorySize, int frequency, string accessXmpProfile, string formFactor, string versionDdr, int usedPower);
}

public class Ram : IRam, IChipSet
{
    private int _memorySize;
    private string? _accessXmpProfile;
    private string? _formFactor;
    private string? _versionDdr;

    public int UsedPower { get; private set; }
    public int MinChipSet { get; set; }
    public int MaxChipSet { get; set; }

    public IRam Builder(int memorySize, int frequency, string accessXmpProfile, string formFactor, string versionDdr, int usedPower)
    {
        return (IRam)new Ram().SetMemorySize(memorySize).SetFrequency(frequency).SetAccessXmpProfile(accessXmpProfile)
            .SetFormFactor(formFactor).SetVersionDdr(versionDdr).SetUsedPower(usedPower);
    }

    public bool Equals(IChipSet? other)
    {
        return other != null && (MaxChipSet >= other.MaxChipSet && other.MinChipSet <= MinChipSet);
    }

    public IRam SetMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IRam SetFrequency(int frequency)
    {
        MinChipSet = frequency;
        MaxChipSet = frequency;
        return this;
    }

    public IRam SetAccessXmpProfile(string accessXmpProfile)
    {
        _accessXmpProfile = accessXmpProfile ?? throw new ArgumentNullException(nameof(accessXmpProfile), $"Null accessXmpProfile");
        return this;
    }

    public IRam SetFormFactor(string formFactor)
    {
        _formFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor), $"Null formFactor");
        return this;
    }

    public IRam SetVersionDdr(string versionDdr)
    {
        _versionDdr = versionDdr ?? throw new ArgumentNullException(nameof(versionDdr), $"Null versionDdr");
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}