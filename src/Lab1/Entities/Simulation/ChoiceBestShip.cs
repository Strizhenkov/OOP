using Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Simulation;

public class ChoiceBestShip
{
    private Calculation _calculation;

    public ChoiceBestShip(Calculation calculation)
    {
        _calculation = calculation;
    }

    public IShip? ResultByFuel()
    {
        double? minCost = null;
        for (int i = 0; i < _calculation.Ships.Count; i++)
        {
            if ((minCost == null || _calculation.WasteMoney[i] < minCost) && _calculation.Result[i])
            {
                minCost = _calculation.WasteMoney[i];
            }
        }

        if (minCost != null)
            return _calculation.Ships[_calculation.WasteMoney.IndexOf((double)minCost)];
        return null;
    }

    public IShip? ResultByTime()
    {
        double? minTime = null;
        for (int i = 0; i < _calculation.Ships.Count; i++)
        {
            if ((minTime == null || _calculation.WasteTime[i] < minTime) && _calculation.Result[i])
            {
                minTime = _calculation.WasteTime[i];
            }
        }

        if (minTime != null)
            return _calculation.Ships[_calculation.WasteTime.IndexOf((double)minTime)];
        return null;
    }
}