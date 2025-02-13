using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IVideoCard : IUsingPowerComponent
{
    IVideoCard SetVideoCardDimensions(int length, int width);
    IVideoCard SetMemorySize(int memorySize);
    IVideoCard SetPciE(string pciE);
    IVideoCard SetChipSet(int maxChipSet, int minChipSet);

    IVideoCard Builder(int length, int width, int memorySize, string pciE, int maxChipSet, int minChipSet, int usedPower);
}

public class VideoCard : IVideoCard, IVideoCore, IChipSet, IDimensions
{
    private int _memorySize;
    private string? _pciE;

    public int UsedPower { get; private set; }
    public int MinChipSet { get; set; }
    public int MaxChipSet { get; set; }
    public bool VideoCore { get; set; } = true;
    public int Length { get; set; }
    public int Width { get; set; }

    public IVideoCard Builder(int length, int width, int memorySize, string pciE, int maxChipSet, int minChipSet, int usedPower)
    {
        return (IVideoCard)new VideoCard().SetVideoCardDimensions(length, width).SetMemorySize(memorySize).SetPciE(pciE)
            .SetChipSet(maxChipSet, minChipSet).SetUsedPower(usedPower);
    }

    public bool Equals(IDimensions? other)
    {
        return other != null && Width <= other.Width && Length <= other.Length;
    }

    public bool Equals(IChipSet? other)
    {
        return other != null && (MaxChipSet >= other.MaxChipSet && other.MinChipSet <= MinChipSet);
    }

    public bool Equals(IVideoCore? other)
    {
        return other != null && (VideoCore || other.VideoCore);
    }

    public IVideoCard SetVideoCardDimensions(int length, int width)
    {
        Length = length;
        Width = width;
        return this;
    }

    public IVideoCard SetMemorySize(int memorySize)
    {
        _memorySize = memorySize;
        return this;
    }

    public IVideoCard SetPciE(string pciE)
    {
        _pciE = pciE ?? throw new ArgumentNullException(nameof(pciE), $"Null pciE");
        return this;
    }

    public IVideoCard SetChipSet(int maxChipSet, int minChipSet)
    {
        MaxChipSet = maxChipSet;
        MinChipSet = minChipSet;
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}