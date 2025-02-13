using System;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;

public interface IPulseDrive
{
    public double[] TravelResult(double distance);
}

public class PulseDrive : IPulseDrive
{
    public virtual double[] TravelResult(double distance)
    {
        return Array.Empty<double>();
    }
}