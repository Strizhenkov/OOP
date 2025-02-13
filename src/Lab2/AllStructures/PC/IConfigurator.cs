using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.Pc;

public interface IConfigurator : ILicense, IReplacer
{
    IConfigurator SetMotherBoard(IMotherBoardFluent motherBoardFluent);
    IConfigurator SetProcessor(IProcessor processor);
    IConfigurator SetRam(IRam ram);
    IConfigurator SetPowerSupply(IPowerSupply powerSupply);
    IConfigurator SetProcessorCoolingSystem(IProcessorCoolingSystem processorCoolingSystem);
    IConfigurator SetDisks(IList<Disk> disks);
    IConfigurator SetVideoCard(IVideoCard? videoCard);
    IConfigurator SetCorpus(ICorpus corpus);
    IConfigurator SetWifiAdapter(IWifiAdapter? wifiAdapter);
    IConfigurator Builder(IMotherBoardFluent motherBoard, IProcessor processor, IRam ram, IProcessorCoolingSystem processorCoolingSystem, IList<Disk> disks, IVideoCard videoCard, ICorpus corpus, IWifiAdapter? wifiAdapter, IPowerSupply powerSupply);
}