using System;
using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Simulation;

public class Calculation
{
    private readonly IList<ISpace> _shipWay;

    public Calculation(IList<IShip> ships, IList<ISpace>? way)
    {
        _shipWay = way ?? throw new ArgumentNullException(nameof(way), $"List of space parts is null");
        Ships = ships ?? throw new ArgumentNullException(nameof(ships), $"List of ships is null");
        Result = new List<bool>();
        WasteTime = new List<double>();
        WasteMoney = new List<double>();
    }

    public IList<IShip> Ships { get; private set; }
    public IList<double> WasteTime { get; private set; }
    public IList<double> WasteMoney { get; private set; }
    public IList<bool> Result { get; private set; }

    public void CalculateResults(double plasmaPrice, double matterPrice)
    {
        foreach (IShip currentShip in Ships)
        {
            var currentShipNavigationLogic = new NavigationLogic(currentShip, _shipWay, plasmaPrice, matterPrice);
            currentShipNavigationLogic.AllWaySimulation();
            if (currentShipNavigationLogic.SimulationStatus == "Way is finished")
            {
                Result.Add(true);
                WasteMoney.Add(currentShipNavigationLogic.CountWasteMoney());
                WasteTime.Add(currentShipNavigationLogic.TimeCount);
            }
            else
            {
                Result.Add(false);
                WasteMoney.Add(0);
                WasteTime.Add(0);
            }
        }
    }
}