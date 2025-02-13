namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;

public class WarpDriveAlpha : WarpDrive
{
    private readonly double _exploitationCost;
    private double _driveSpeed;

    public WarpDriveAlpha(double exploitationCost, double driveSpeed, double maxWarpDistance)
    {
        _exploitationCost = exploitationCost;
        _driveSpeed = driveSpeed;
        MaxWarpDistance = maxWarpDistance;
    }

    public override double[] TravelResult(double distance)
    {
        double[] result;
        result = new double[2];
        result[0] = _exploitationCost * distance / _driveSpeed;
        result[1] = distance / _driveSpeed;
        return result;
    }
}