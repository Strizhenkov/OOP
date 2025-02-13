using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Simulation;

public class NavigationLogic
{
    private readonly double _plasmaPrice;
    private readonly double _matterPrice;
    private double _plasmaFuelCount;
    private double _matterFuelCount;
    private IShip _ship;
    private IList<ISpace> _way;

    public NavigationLogic(IShip ship, IList<ISpace> way, double plasmaPrice, double matterPrice)
    {
        _plasmaPrice = plasmaPrice;
        _matterPrice = matterPrice;
        _plasmaFuelCount = 0;
        _matterFuelCount = 0;
        _ship = ship;
        _way = way ?? throw new ArgumentNullException(nameof(way), $"List of space parts is null");
    }

    public string SimulationStatus { get; private set; } = "Not Finish";

    public double TimeCount { get; private set; }

    public double CountWasteMoney()
    {
        return (_matterFuelCount * _matterPrice) + (_plasmaFuelCount * _plasmaPrice);
    }

    public void AllWaySimulation()
    {
        foreach (ISpace partOfWay in _way)
        {
            SectorSimulation(partOfWay);
            if (partOfWay.RequiredFuelType == "MatterFuel")
                _matterFuelCount += SectorMatterFuelCount(partOfWay);
            else
                _plasmaFuelCount += SectorPlasmaFuelCount(partOfWay);
            TimeCount += SectorTimeCount(partOfWay);
            ShipStatusCheck(partOfWay);
        }

        if (SimulationStatus == "Not Finish")
            SimulationStatus = "Way is finished";
    }

    private void SectorSimulation(ISpace currentSpace)
    {
        if (currentSpace.Barriers != null)
        {
            foreach (IBarrier currentBarrier in currentSpace.Barriers)
            {
                if (_ship.Deflector != null && currentBarrier is AntimatterFlash && _ship.Deflector is PhotonDeflector)
                {
                    _ship.Deflector.CountDamage(currentBarrier.Damage);
                }
                else if ((_ship.Deflector == null || _ship.Deflector is not PhotonDeflector) && currentBarrier is AntimatterFlash)
                {
                    _ship.CrewDead();
                }
                else if (_ship.AntiNitrineReflector != null && currentBarrier is SpaceWhale)
                {
                }
                else if (_ship.Deflector != null)
                {
                    if (_ship.Deflector.HealthPoints <= 0)
                        _ship.Deflector.DeflectorOff();
                    if (_ship.Deflector.HealthPoints > 0 && currentBarrier.Damage <= _ship.Deflector.HealthPoints)
                    {
                        _ship.Deflector.CountDamage(currentBarrier.Damage);
                    }
                    else if (currentBarrier.Damage > _ship.Deflector.HealthPoints)
                    {
                        _ship.Hull.CountDamage(currentBarrier.Damage - _ship.Deflector.HealthPoints);
                        _ship.Deflector.CountDamage(_ship.Deflector.HealthPoints);
                    }
                    else
                    {
                        _ship.Hull.CountDamage(currentBarrier.Damage);
                    }
                }
            }
        }
    }

    private double SectorPlasmaFuelCount(ISpace currentSpace)
    {
        return _ship.PulseDrive.TravelResult(currentSpace.Distance)[0];
    }

    private double SectorMatterFuelCount(ISpace currentSpace)
    {
        if (_ship.WarpDrive != null)
            return _ship.WarpDrive.TravelResult(currentSpace.Distance)[0];
        return 0;
    }

    private double SectorTimeCount(ISpace currentSpace)
    {
        if (currentSpace.RequiredFuelType == "MatterFuel")
        {
            if (_ship.WarpDrive != null)
                return _ship.WarpDrive.TravelResult(currentSpace.Distance)[1];
            return 0;
        }

        return _ship.PulseDrive.TravelResult(currentSpace.Distance)[1];
    }

    private void ShipStatusCheck(ISpace currentSpace)
    {
        if (HullCheck())
            SimulationStatus = "Ship is destroyed";
        if (CrewCheck())
            SimulationStatus = "Crew is dead";
        if (WarpDriveExistenceCheck(currentSpace))
            SimulationStatus = "No WarpDrive on ship";
        if (WarpDriveDistanceCheck(currentSpace))
            SimulationStatus = "Bad WarpDrive on ship";
        if (PulseDriveCheck(currentSpace))
            SimulationStatus = "Bad PulseDrive on ship";
    }

    private bool PulseDriveCheck(ISpace currentSpace)
    {
        return _ship.PulseDrive is PulseDriveC && currentSpace is NitrineParticlesSpace;
    }

    private bool WarpDriveExistenceCheck(ISpace currentSpace)
    {
        return currentSpace is DenseSpace && _ship.WarpDrive is null;
    }

    private bool WarpDriveDistanceCheck(ISpace currentSpace)
    {
        return _ship.WarpDrive != null && _ship.WarpDrive.MaxWarpDistance < currentSpace.Distance &&
               currentSpace is DenseSpace;
    }

    private bool HullCheck()
    {
        return _ship.Hull.HealthPoints < 0;
    }

    private bool CrewCheck()
    {
        return !_ship.CrewLifeStatus;
    }
}