using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.Pc;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;
using Itmo.ObjectOrientedProgramming.Lab2.AllStructures.SupportInterfaces;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab2.Tests;

public class Tests
{
    [Fact]
    public void FirstTest()
    {
        IBios bios = new Bios().Builder("10", "2.8.3", "Proc");
        IMotherBoardFluent board = new MotherBoardFluent().Builder("Socket 1", 2, 2, 50, 100, "DDR1", "123", bios);
        IProcessor processor = new Processor().Builder(60, 4, "Socket 1", false, 70, 400, 10);
        IRam ram = new Ram().Builder(6, 70, "XMP", "123", "DDR1", 12);
        IProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingSystem().Builder(40, 50, "Socket 1", 500);
        SsdDrive ssdDrive = new SsdDrive().Builder("1", 256, 300, 1);
        HardDrive hardDrive = new HardDrive().Builder(256, 200, 3);
        var myDisks = new List<Disk> { ssdDrive, hardDrive };
        IVideoCard videoCard = new VideoCard().Builder(15, 20,  8, "2", 70, 80, 5);
        ICorpus corpus = new Corpus().Builder(30, 20, "123", 60, 70);
        IWifiAdapter wifiAdapter = new WifiAdapter().Builder("1.2.3", false, "123", 3);
        IPowerSupply powerSupply = new PowerSupply().Builder(50);
        IConfigurator myPc = new Pc().Builder(board, processor, ram, processorCoolingSystem, myDisks, videoCard, corpus, wifiAdapter, powerSupply);
        Assert.Equal("PC is correct", myPc.LicenseStatus);
    }

    [Fact]
    public void SecondTest()
    {
        IBios bios = new Bios().Builder("10", "2.8.3", "Proc");
        IMotherBoardFluent board = new MotherBoardFluent().Builder("Socket 1", 2, 2, 50, 100, "DDR1", "123", bios);
        IProcessor processor = new Processor().Builder(60, 4, "Socket 1", false, 70, 400, 10);
        IRam ram = new Ram().Builder(6, 70, "XMP", "123", "DDR1", 12);
        IProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingSystem().Builder(40, 50, "Socket 1", 500);
        SsdDrive ssdDrive = new SsdDrive().Builder("1", 256, 300, 1);
        HardDrive hardDrive = new HardDrive().Builder(256, 200, 3);
        var myDisks = new List<Disk> { ssdDrive, hardDrive };
        IVideoCard videoCard = new VideoCard().Builder(15, 20,  8, "2", 70, 80, 5);
        ICorpus corpus = new Corpus().Builder(30, 20, "123", 60, 70);
        IWifiAdapter wifiAdapter = new WifiAdapter().Builder("1.2.3", false, "123", 3);
        IPowerSupply powerSupply = new PowerSupply().Builder(10);
        IConfigurator myPc = new Pc().Builder(board, processor, ram, processorCoolingSystem, myDisks, videoCard, corpus, wifiAdapter, powerSupply);
        Assert.Equal("Overused power", myPc.LicenseStatus);
    }

    [Fact]
    public void ThirdTest()
    {
        IBios bios = new Bios().Builder("10", "2.8.3", "Proc");
        IMotherBoardFluent board = new MotherBoardFluent().Builder("Socket 1", 2, 2, 50, 100, "DDR1", "123", bios);
        IProcessor processor = new Processor().Builder(60, 4, "Socket 1", false, 70, 400, 10);
        IRam ram = new Ram().Builder(6, 70, "XMP", "123", "DDR1", 12);
        IProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingSystem().Builder(40, 50, "Socket 1", 300);
        SsdDrive ssdDrive = new SsdDrive().Builder("1", 256, 300, 1);
        HardDrive hardDrive = new HardDrive().Builder(256, 200, 3);
        var myDisks = new List<Disk> { ssdDrive, hardDrive };
        IVideoCard videoCard = new VideoCard().Builder(15, 20,  8, "2", 70, 80, 5);
        ICorpus corpus = new Corpus().Builder(30, 20, "123", 60, 70);
        IWifiAdapter wifiAdapter = new WifiAdapter().Builder("1.2.3", false, "123", 3);
        IPowerSupply powerSupply = new PowerSupply().Builder(50);
        ConfiguratorException ex = Assert.Throws<ConfiguratorException>(() => new Pc().Builder(board, processor, ram, processorCoolingSystem, myDisks, videoCard, corpus, wifiAdapter, powerSupply));
        Assert.Equal("ProcessorCoolingSystem invalid with Processor", ex.Message);
    }

    [Fact]
    public void FourthTest()
    {
        IBios bios = new Bios().Builder("10", "2.8.3", "Proc");
        IMotherBoardFluent board = new MotherBoardFluent().Builder("Socket 1", 2, 2, 50, 100, "DDR1", "123", bios);
        IProcessor processor = new Processor().Builder(60, 4, "Socket 1", false, 70, 400, 10);
        IRam ram = new Ram().Builder(6, 70, "XMP", "123", "DDR1", 12);
        IProcessorCoolingSystem processorCoolingSystem = new ProcessorCoolingSystem().Builder(40, 50, "Socket 1", 500);
        SsdDrive ssdDrive = new SsdDrive().Builder("1", 256, 300, 1);
        HardDrive hardDrive = new HardDrive().Builder(256, 200, 3);
        var myDisks = new List<Disk> { ssdDrive, hardDrive };
        ICorpus corpus = new Corpus().Builder(30, 20, "123", 60, 70);
        IWifiAdapter wifiAdapter = new WifiAdapter().Builder("1.2.3", false, "123", 3);
        IPowerSupply powerSupply = new PowerSupply().Builder(50);
        ConfiguratorException ex = Assert.Throws<ConfiguratorException>(() => new Pc().Builder(board, processor, ram, processorCoolingSystem, myDisks, null, corpus, wifiAdapter, powerSupply));
        Assert.Equal("No VideoCard or VideoCore in Processor", ex.Message);
    }
}