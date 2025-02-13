using System;
namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;

public class PulseDriveE : PulseDrive
{
    private readonly double _activationCost;
    private readonly double _exploitationCost;
    private double _driveSpeed;

    public PulseDriveE(double activationCost, double exploitationCost, double driveSpeed)
    {
        _activationCost = activationCost;
        _exploitationCost = exploitationCost;
        _driveSpeed = driveSpeed;
    }

    public override double[] TravelResult(double distance)
    {
        double[] result;
        result = new double[2];
        result[0] = (_exploitationCost * Math.Sqrt(2 * distance / _driveSpeed)) + _activationCost;
        result[1] = Math.Sqrt(2 * distance / _driveSpeed);
        return result;
    }
}