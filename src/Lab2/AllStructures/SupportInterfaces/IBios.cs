using System;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IBios
{
    IBios SetType(string type);
    IBios SetVersion(string version);
    IBios SetSupportedProcessorsList(string supportedProcessorsList);

    IBios Builder(string type, string version, string supportedProcessorsList);
}

public class Bios : IBios
{
    private string? _type;
    private string? _version;
    private string? _supportedProcessorsList;
    public bool BuildStatus { get; private set; }

    public IBios Builder(string type, string version, string supportedProcessorsList)
    {
        BuildStatus = true;
        return new Bios().SetType(type).SetVersion(version).SetSupportedProcessorsList(supportedProcessorsList);
    }

    public IBios SetType(string type)
    {
        _type = type ?? throw new ArgumentNullException(nameof(type), $"Null type");
        return this;
    }

    public IBios SetVersion(string version)
    {
        _version = version ?? throw new ArgumentNullException(nameof(version), $"Null version");
        return this;
    }

    public IBios SetSupportedProcessorsList(string supportedProcessorsList)
    {
        _supportedProcessorsList = supportedProcessorsList ?? throw new ArgumentNullException(nameof(supportedProcessorsList), $"Null supportedProcessorsList");
        return this;
    }
}