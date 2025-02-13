using System.Collections.Generic;
using System.Collections.ObjectModel;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Simulation;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

public class Test
{
    [Fact]
    public void FirstTest()
    {
        // Создание шатла
        var shuttlePulseDrive = new PulseDriveC(1, 1, 1);
        var shuttle = new Shuttle(shuttlePulseDrive);

        // Создание Авгура
        var avgurPulseDrive = new PulseDriveE(2, 5, 10);
        var avgurWarpDrive = new WarpDriveAlpha(10, 2, 100);
        var avgur = new Avgur(avgurPulseDrive, avgurWarpDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var firstSector = new DenseSpace(150, null);
        path.Add(firstSector);

        // Симуляция
        var shuttleNavigationLogic = new NavigationLogic(shuttle, path, 1, 1);
        var avgurNavigationLogic = new NavigationLogic(avgur, path, 1, 1);
        shuttleNavigationLogic.AllWaySimulation();
        avgurNavigationLogic.AllWaySimulation();
        Assert.Equal("No WarpDrive on ship", shuttleNavigationLogic.SimulationStatus);
        Assert.Equal("Bad WarpDrive on ship", avgurNavigationLogic.SimulationStatus);
    }

    [Fact]
    public void SecondTest()
    {
        // Создание Валкаса без фотоного дефлектратора
        var valcasPulseDrive = new PulseDriveE(2, 10, 15);
        var valsacWarpDrive = new WarpDriveGamma(3, 10, 60);
        var valcas = new Valcas(valcasPulseDrive, valsacWarpDrive);

        // Создание Валкаса c фотоным дефлектратором
        var photonValcas = new PhotonValcas(valcasPulseDrive, valsacWarpDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var barrier = new AntimatterFlash();
        var firstSectorBarriers = new List<IDenseSpaceBarriers>() { barrier };
        var firstSectorBarriersCollection = new ReadOnlyCollection<IDenseSpaceBarriers>(firstSectorBarriers);
        var firstSector = new DenseSpace(15, firstSectorBarriersCollection);
        path.Add(firstSector);

        // Симуляция
        var valcasNavigationLogic = new NavigationLogic(valcas, path, 1, 1);
        var photonValcasNavigationLogic = new NavigationLogic(photonValcas, path, 1, 1);
        valcasNavigationLogic.AllWaySimulation();
        photonValcasNavigationLogic.AllWaySimulation();
        Assert.Equal("Crew is dead", valcasNavigationLogic.SimulationStatus);
        Assert.Equal("Way is finished", photonValcasNavigationLogic.SimulationStatus);
    }

    [Fact]
    public void ThirdTest()
    {
        // Создание Валкаса
        var valcasPulseDrive = new PulseDriveE(2, 10, 15);
        var valsacWarpDrive = new WarpDriveGamma(3, 10, 60);
        var valcas = new Valcas(valcasPulseDrive, valsacWarpDrive);

        // Создание Авгура
        var avgurPulseDrive = new PulseDriveE(2, 5, 10);
        var avgurWarpDrive = new WarpDriveAlpha(10, 2, 100);
        var avgur = new Avgur(avgurPulseDrive, avgurWarpDrive);

        // Создание Меридиана
        var meridianPulseDrive = new PulseDriveE(2, 5, 2);
        var meridian = new Meridian(meridianPulseDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var barrier = new SpaceWhale();
        var firstSectorBarriers = new List<INitrineParticlesSpaceBarriers>() { barrier };
        var firstSectorBarriersCollection = new ReadOnlyCollection<INitrineParticlesSpaceBarriers>(firstSectorBarriers);
        var firstSector = new NitrineParticlesSpace(15, firstSectorBarriersCollection);
        path.Add(firstSector);

        // Симуляция
        var valcasNavigationLogic = new NavigationLogic(valcas, path, 1, 1);
        var avgurNavigationLogic = new NavigationLogic(avgur, path, 1, 1);
        var meridianNavigationLogic = new NavigationLogic(meridian, path, 1, 1);
        valcasNavigationLogic.AllWaySimulation();
        avgurNavigationLogic.AllWaySimulation();
        meridianNavigationLogic.AllWaySimulation();
        Assert.Equal("Ship is destroyed", valcasNavigationLogic.SimulationStatus);
        Assert.Equal("Way is finished", avgurNavigationLogic.SimulationStatus);
        Assert.Equal("Way is finished", meridianNavigationLogic.SimulationStatus);
        if (avgur.Deflector != null) Assert.Equal(0, avgur.Deflector.HealthPoints);
        Assert.Equal(20, avgur.Hull.HealthPoints);
        if (meridian.Deflector != null) Assert.Equal(10, meridian.Deflector.HealthPoints);
        Assert.Equal(5, meridian.Hull.HealthPoints);
    }

    [Fact]
    public void FourthTest()
    {
        // Создание шатла
        var shuttlePulseDrive = new PulseDriveC(1, 1, 1);
        var shuttle = new Shuttle(shuttlePulseDrive);

        // Создание Валкаса
        var valcasPulseDrive = new PulseDriveE(30, 15, 4);
        var valsacWarpDrive = new WarpDriveGamma(3, 10, 60);
        var valcas = new Valcas(valcasPulseDrive, valsacWarpDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var firstSector = new BasicSpace(150, null);
        path.Add(firstSector);

        // Симуляция
        var listOfShips = new List<IShip> { shuttle, valcas };
        var calculation = new Calculation(listOfShips, path);
        calculation.CalculateResults(1, 1);
        Assert.Equal(shuttle, new ChoiceBestShip(calculation).ResultByFuel());
    }

    [Fact]
    public void FifthTest()
    {
        // Создание Авгура
        var avgurPulseDrive = new PulseDriveE(2, 5, 10);
        var avgurWarpDrive = new WarpDriveAlpha(10, 2, 80);
        var avgur = new Avgur(avgurPulseDrive, avgurWarpDrive);

        // Создание Стеллы
        var stellaPulseDrive = new PulseDriveC(1, 1, 1);
        var stellaWarpDrive = new WarpDriveOmega(1, 1, 200);
        var stella = new Stella(stellaPulseDrive, stellaWarpDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var firstSectorBarriers = new List<IDenseSpaceBarriers>() { };
        var firstSectorBarriersCollection = new ReadOnlyCollection<IDenseSpaceBarriers>(firstSectorBarriers);
        var firstSector = new DenseSpace(100, firstSectorBarriersCollection);
        path.Add(firstSector);

        // Симуляция
        var listOfShips = new List<IShip> { avgur, stella };
        var calculation = new Calculation(listOfShips, path);
        calculation.CalculateResults(1, 1);
        Assert.Equal(stella, new ChoiceBestShip(calculation).ResultByTime());
    }

    [Fact]
    public void SixthTest()
    {
        // Создание шатла
        var shuttlePulseDrive = new PulseDriveC(1, 1, 1);
        var shuttle = new Shuttle(shuttlePulseDrive);

        // Создание Валкаса
        var valcasPulseDrive = new PulseDriveE(30, 15, 4);
        var valsacWarpDrive = new WarpDriveGamma(3, 10, 60);
        var valcas = new Valcas(valcasPulseDrive, valsacWarpDrive);

        // Создание маршрута
        var path = new List<ISpace>() { };
        var firstSector = new DenseSpace(50, null);
        path.Add(firstSector);

        // Симуляция
        var listOfShips = new List<IShip> { shuttle, valcas };
        var calculation = new Calculation(listOfShips, path);
        calculation.CalculateResults(1, 1);
        Assert.Equal(valcas, new ChoiceBestShip(calculation).ResultByFuel());
    }

    [Fact]
    public void SeventhTest()
    {
        // Создание Авгура
        var avgurPulseDrive = new PulseDriveE(2, 5, 10);
        var avgurWarpDrive = new WarpDriveAlpha(10, 2, 80);
        var avgur = new Avgur(avgurPulseDrive, avgurWarpDrive);

        // Создание маршрута
        var meteorite = new Meteorite();
        var bigStoneAsteroid = new Asteroid();
        var firstSectorBarriers = new List<IBasicSpaceBarriers>() { meteorite, bigStoneAsteroid, meteorite, meteorite };
        var firstSectorBarriersCollection = new ReadOnlyCollection<IBasicSpaceBarriers>(firstSectorBarriers);
        var firstSector = new BasicSpace(50, firstSectorBarriersCollection);
        var whale = new SpaceWhale();
        var secondSectorBarriers = new List<INitrineParticlesSpaceBarriers>() { whale };
        var secondSectorBarriersCollection = new ReadOnlyCollection<INitrineParticlesSpaceBarriers>(secondSectorBarriers);
        var secondSector = new NitrineParticlesSpace(100, secondSectorBarriersCollection);
        var thirdSector = new DenseSpace(50, null);
        var path = new List<ISpace>() { firstSector, secondSector, thirdSector };

        // Симуляция
        var avgurNavigationLogic = new NavigationLogic(avgur, path, 1, 1);
        avgurNavigationLogic.AllWaySimulation();
        Assert.Equal("Way is finished", avgurNavigationLogic.SimulationStatus);
    }
}