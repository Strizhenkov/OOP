using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface ICorpus : IUsingPowerComponent
{
    ICorpus SetMaxVideoCardDimensions(int length, int width);
    ICorpus SetSupportedFormFactorsOfMotherBoard(string supportedFormFactorsOfMotherBoard);
    ICorpus SetCorpusDimensions(int length, int width);
    ICorpus Builder(int maxVideoCardLength, int maxVideoCardWidth, string supportedFormFactorsOfMotherBoard, int maxCorpusLength, int maxCorpusWidth);
}

public class Corpus : ICorpus, IDimensions
{
    private string? _supportedFormFactorsOfMotherBoard;
    private int _corpusLength;
    private int _corpusWidth;

    public int UsedPower { get; private set; }
    public int Length { get; set; }
    public int Width { get; set; }

    public ICorpus Builder(int maxVideoCardLength, int maxVideoCardWidth, string supportedFormFactorsOfMotherBoard, int maxCorpusLength, int maxCorpusWidth)
    {
        return new Corpus().SetMaxVideoCardDimensions(maxVideoCardLength, maxVideoCardWidth)
            .SetSupportedFormFactorsOfMotherBoard(supportedFormFactorsOfMotherBoard)
            .SetCorpusDimensions(maxCorpusLength, maxCorpusWidth);
    }

    public bool Equals(IDimensions? other)
    {
        return other != null && Length >= other.Length && Width >= other.Width;
    }

    public ICorpus SetMaxVideoCardDimensions(int length, int width)
    {
        Length = length;
        Width = width;
        return this;
    }

    public ICorpus SetSupportedFormFactorsOfMotherBoard(string supportedFormFactorsOfMotherBoard)
    {
        _supportedFormFactorsOfMotherBoard = supportedFormFactorsOfMotherBoard ?? throw new ArgumentNullException(nameof(supportedFormFactorsOfMotherBoard), $"Null supportedFormFactorsOfMotherBoard");
        return this;
    }

    public ICorpus SetCorpusDimensions(int length, int width)
    {
        if (Length > length || Width > width)
        {
            throw new ConfiguratorException("Corpus size smaller then VideoCard size");
        }

        _corpusLength = length;
        _corpusWidth = width;
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}