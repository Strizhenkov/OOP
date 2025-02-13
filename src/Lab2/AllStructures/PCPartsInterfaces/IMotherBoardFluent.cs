using System;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IMotherBoardFluent : IUsingPowerComponent
{
    IMotherBoardFluent SetSocket(string? socket);
    IMotherBoardFluent SetPciE(int pciELines);
    IMotherBoardFluent SetSataPorts(int sataPorts);
    IMotherBoardFluent SetChipSet(int minChipSet, int maxChipSet);
    IMotherBoardFluent SetDdr(string ddr);
    IMotherBoardFluent SetFormFactor(string formFactor);
    IMotherBoardFluent SetBios(IBios bios);
    IMotherBoardFluent Builder(string socket, int pciELines, int sataPorts, int minChipSet, int maxChipsSet, string ddr, string formFactor, IBios bios);
}

public class MotherBoardFluent : IMotherBoardFluent, ISocket, IChipSet
{
    private int _pciELines;
    private int _sataPorts;
    private string? _ddr;
    private string? _formFactor;
    private IBios? _bios;

    public int UsedPower { get; private set; }
    public int MinChipSet { get; set; }
    public int MaxChipSet { get; set; }

    public string? SocketName { get; set; }

    public IMotherBoardFluent Builder(string socket, int pciELines, int sataPorts, int minChipSet, int maxChipsSet, string ddr, string formFactor, IBios bios)
    {
        return new MotherBoardFluent().SetSocket(socket).SetPciE(pciELines).SetSataPorts(sataPorts).SetChipSet(minChipSet, maxChipsSet)
            .SetDdr(ddr).SetFormFactor(formFactor).SetBios(bios);
    }

    public bool Equals(IChipSet? other)
    {
        return other != null && (MaxChipSet >= other.MaxChipSet && other.MinChipSet >= MinChipSet);
    }

    public bool Equals(ISocket? other)
    {
        return other != null && SocketName == other.SocketName;
    }

    public IMotherBoardFluent SetSocket(string? socket)
    {
        SocketName = socket ?? throw new ArgumentNullException(nameof(socket), $"Null socket");
        return this;
    }

    public IMotherBoardFluent SetPciE(int pciELines)
    {
        _pciELines = pciELines;
        return this;
    }

    public IMotherBoardFluent SetSataPorts(int sataPorts)
    {
        _sataPorts = sataPorts;
        return this;
    }

    public IMotherBoardFluent SetChipSet(int minChipSet, int maxChipSet)
    {
        MinChipSet = minChipSet;
        MaxChipSet = maxChipSet;
        return this;
    }

    public IMotherBoardFluent SetDdr(string ddr)
    {
        _ddr = ddr ?? throw new ArgumentNullException(nameof(ddr), $"Null ddr");
        return this;
    }

    public IMotherBoardFluent SetFormFactor(string formFactor)
    {
        _formFactor = formFactor ?? throw new ArgumentNullException(nameof(formFactor), $"Null formFactor");
        return this;
    }

    public IMotherBoardFluent SetBios(IBios bios)
    {
        _bios = bios ?? throw new ArgumentNullException(nameof(bios), $"Null bios");
        return this;
    }

    public IUsingPowerComponent SetUsedPower(int usedPower)
    {
        UsedPower = usedPower;
        return this;
    }
}