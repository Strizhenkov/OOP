using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.Pc;

public interface IReplacer
{
    IReplacer Replace(IVideoCard newVideoCard);
    IReplacer Replace(IMotherBoardFluent newMotherBoard);
    IReplacer Replace(IProcessor newProcessor);
    IReplacer Replace(IProcessorCoolingSystem newProcessorCoolingSystem);
    IReplacer Replace(ICorpus newCorpus);
    IReplacer Replace(IWifiAdapter newWifiAdapter);
    IReplacer Replace(IRam newRam);
    IReplacer Replace(IList<Disk> newDisks);
}