using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;

public interface IWarpDrive
{
    public double[] TravelResult(double distance);
}

public class WarpDrive : IWarpDrive
{
    public double MaxWarpDistance { get; protected set; }

    public virtual double[] TravelResult(double distance)
    {
        return Array.Empty<double>();
    }
}