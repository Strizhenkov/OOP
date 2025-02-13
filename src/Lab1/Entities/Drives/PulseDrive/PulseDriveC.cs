namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;

public class PulseDriveC : PulseDrive
{
    private readonly double _activationCost;
    private readonly double _exploitationCost;
    private double _driveSpeed;

    public PulseDriveC(double activationCost, double exploitationCost, double driveSpeed)
    {
        _activationCost = activationCost;
        _exploitationCost = exploitationCost;
        _driveSpeed = driveSpeed;
    }

    public override double[] TravelResult(double distance)
    {
        double[] result;
        result = new double[2];
        result[0] = (_exploitationCost * distance / _driveSpeed) + _activationCost;
        result[1] = distance / _driveSpeed;
        return result;
    }
}