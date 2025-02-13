using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.Pc;

public class Pc : IConfigurator
{
    private readonly List<IUsingPowerComponent> _components = new List<IUsingPowerComponent>();
    private MotherBoardFluent? _motherBoard;
    private Processor? _processor;
    private Ram? _ram;
    private PowerSupply? _powerSupply;
    private IList<Disk>? _disks;
    private VideoCard? _videoCard;
    private ProcessorCoolingSystem? _processorCoolingSystem;
    private Corpus? _corpus;
    private WifiAdapter? _wifiAdapter;

    public string? LicenseStatus { get; set; } = "PC is correct";

    public IConfigurator Builder(IMotherBoardFluent motherBoard, IProcessor processor, IRam ram, IProcessorCoolingSystem processorCoolingSystem, IList<Disk> disks, IVideoCard? videoCard, ICorpus corpus, IWifiAdapter? wifiAdapter, IPowerSupply powerSupply)
    {
        return new Pc().SetMotherBoard(motherBoard).SetProcessor(processor).SetRam(ram).SetProcessorCoolingSystem(processorCoolingSystem).SetDisks(disks).SetVideoCard(videoCard).SetCorpus(corpus).SetWifiAdapter(wifiAdapter).SetPowerSupply(powerSupply);
    }

    public IConfigurator SetMotherBoard(IMotherBoardFluent motherBoardFluent)
    {
        _motherBoard = (MotherBoardFluent?)motherBoardFluent;
        _components.Add(motherBoardFluent);
        return this;
    }

    public IConfigurator SetProcessor(IProcessor processor)
    {
        _processor = (Processor)processor;
        _components.Add(processor);
        if (_processor != null && _motherBoard != null && _motherBoard.Equals((ISocket)_processor))
        {
            return this;
        }

        throw new ConfiguratorException("Processor invalid with MotherBoard");
    }

    public IConfigurator SetRam(IRam ram)
    {
        _ram = (Ram)ram;
        _components.Add(ram);
        if (_motherBoard != null && _ram != null && _motherBoard.Equals((IChipSet)_ram))
        {
             return this;
        }

        throw new ConfiguratorException("Ram invalid with MotherBoard");
    }

    public IConfigurator SetDisks(IList<Disk> disks)
    {
        if (disks == null || disks.Count == 0)
        {
            throw new ConfiguratorException("No any disks");
        }

        _disks = disks;
        foreach (Disk disk in disks) _components.Add(disk);
        return this;
    }

    public IConfigurator SetVideoCard(IVideoCard? videoCard)
    {
        if (_processor is { VideoCore: false } && videoCard == null)
        {
            throw new ConfiguratorException("No VideoCard or VideoCore in Processor");
        }

        if (videoCard == null)
        {
            return this;
        }

        _videoCard = (VideoCard)videoCard;
        _components.Add(videoCard);
        if (_motherBoard != null && _motherBoard.Equals((IChipSet)_videoCard))
        {
            return this;
        }

        throw new ConfiguratorException("VideoCard invalid with MotherBoard");
    }

    public IConfigurator SetProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem)
    {
        _processorCoolingSystem = (ProcessorCoolingSystem)processorCoolingSystem;
        _components.Add(processorCoolingSystem);
        if (_processor != null && !_processor.Equals((ITdp)_processorCoolingSystem))
        {
            throw new ConfiguratorException("ProcessorCoolingSystem invalid with Processor");
        }

        if (_motherBoard != null && !_motherBoard.Equals((ISocket)_processorCoolingSystem))
        {
            throw new ConfiguratorException("ProcessorCoolingSystem invalid with MotherBoard");
        }

        return this;
    }

    public IConfigurator SetCorpus(ICorpus corpus)
    {
        _corpus = (Corpus)corpus;
        _components.Add(corpus);
        if (_videoCard != null && _videoCard.Equals((IDimensions)_corpus))
        {
            return this;
        }

        throw new ConfiguratorException("Corpus invalid with VideoCard");
    }

    public IConfigurator SetWifiAdapter(IWifiAdapter? wifiAdapter)
    {
        if (wifiAdapter == null)
        {
            return this;
        }

        _wifiAdapter = (WifiAdapter)wifiAdapter;
        _components.Add(wifiAdapter);
        return this;
    }

    public IConfigurator SetPowerSupply(IPowerSupply powerSupply)
    {
        _powerSupply = (PowerSupply?)powerSupply;
        if (_powerSupply != null && _components.Sum(component => component.UsedPower) > _powerSupply.MaxUsedPower)
        {
            LicenseStatus = "Overused power";
        }

        return this;
    }

    public IReplacer Replace(IVideoCard newVideoCard)
    {
        if (_videoCard != null) _components.Remove(_videoCard);
        IConfigurator modifiedPc = SetVideoCard(newVideoCard);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IMotherBoardFluent newMotherBoard)
    {
        if (_motherBoard != null) _components.Remove(_motherBoard);
        IConfigurator modifiedPc = SetMotherBoard(newMotherBoard);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IProcessor newProcessor)
    {
        if (_processor != null) _components.Remove(_processor);
        IConfigurator modifiedPc = SetProcessor(newProcessor);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IRam newRam)
    {
        if (_ram != null) _components.Remove(_ram);
        IConfigurator modifiedPc = SetRam(newRam);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IProcessorCoolingSystem newProcessorCoolingSystem)
    {
        if (_processorCoolingSystem != null) _components.Remove(_processorCoolingSystem);
        IConfigurator modifiedPc = SetProcessorCoolingSystem(newProcessorCoolingSystem);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(ICorpus newCorpus)
    {
        if (_corpus != null) _components.Remove(_corpus);
        IConfigurator modifiedPc = SetCorpus(newCorpus);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IWifiAdapter newWifiAdapter)
    {
        if (_wifiAdapter != null) _components.Remove(_wifiAdapter);
        IConfigurator modifiedPc = SetWifiAdapter(newWifiAdapter);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    public IReplacer Replace(IList<Disk> newDisks)
    {
        if (_disks != null) foreach (Disk disk in _disks) _components.Remove(disk);
        IConfigurator modifiedPc = SetDisks(newDisks);
        CheckParts((Pc)modifiedPc);
        return modifiedPc;
    }

    private void CheckParts(Pc modifiedPc)
    {
        if (modifiedPc == null)
        {
            throw new ArgumentNullException(nameof(modifiedPc), "Null Pc");
        }

        if (modifiedPc._powerSupply != null && modifiedPc._components.Sum(component => component.UsedPower) > modifiedPc._powerSupply.MaxUsedPower)
        {
            modifiedPc.LicenseStatus = "Overused power";
        }

        if (modifiedPc is { _videoCard: not null, _corpus: not null } && !modifiedPc._videoCard.Equals((IDimensions)modifiedPc._corpus))
        {
            throw new ConfiguratorException("Corpus invalid with VideoCard");
        }

        if (modifiedPc is { _processor: not null, _processorCoolingSystem: not null } && !modifiedPc._processor.Equals((ITdp)modifiedPc._processorCoolingSystem))
        {
            throw new ConfiguratorException("ProcessorCoolingSystem invalid with Processor");
        }

        if (modifiedPc is { _motherBoard: not null, _processorCoolingSystem: not null } && !modifiedPc._motherBoard.Equals((ISocket)modifiedPc._processorCoolingSystem))
        {
            throw new ConfiguratorException("ProcessorCoolingSystem invalid with MotherBoard");
        }

        if (modifiedPc._processor is { VideoCore: false } || _videoCard == null)
        {
            throw new ConfiguratorException("No VideoCard or VideoCore in Processor");
        }

        if (modifiedPc is { _motherBoard: not null, _videoCard: not null } && !modifiedPc._motherBoard.Equals((IChipSet)modifiedPc._videoCard))
        {
            throw new ConfiguratorException("VideoCard invalid with MotherBoard");
        }

        if (modifiedPc._disks == null || modifiedPc._disks.Count == 0)
        {
            throw new ConfiguratorException("No any disks");
        }

        if (modifiedPc is { _motherBoard: not null, _ram: not null } && !modifiedPc._motherBoard.Equals((IChipSet)modifiedPc._ram))
        {
            throw new ConfiguratorException("Ram invalid with MotherBoard");
        }

        if (modifiedPc._processor != null && modifiedPc._motherBoard != null && !modifiedPc._motherBoard.Equals((ISocket)modifiedPc._processor))
        {
            throw new ConfiguratorException("Processor invalid with MotherBoard");
        }
    }
}