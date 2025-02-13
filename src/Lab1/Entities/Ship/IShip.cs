using Itmo.ObjectOrientedProgramming.Lab1.Entities.AntiNitrineReflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public interface IShip
{
    bool CrewLifeStatus { get; }
    Hull.Hull Hull { get; }
    PulseDrive PulseDrive { get; }
    WarpDrive? WarpDrive { get; }
    Deflector.Deflector? Deflector { get; }
    IAntiNitrineReflector? AntiNitrineReflector { get; }
    void CrewDead();
}