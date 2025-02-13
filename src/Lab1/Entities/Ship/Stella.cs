using Itmo.ObjectOrientedProgramming.Lab1.Entities.AntiNitrineReflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Stella : IShip
{
    public Stella(PulseDriveC pulseDrive, WarpDriveOmega warpDrive)
    {
        CrewLifeStatus = true;
        Hull = new HullClass1();
        PulseDrive = pulseDrive;
        WarpDrive = warpDrive;
        Deflector = new DeflectorClass1();
    }

    public bool CrewLifeStatus { get; private set; }
    public Hull.Hull Hull { get; private set; }
    public PulseDrive PulseDrive { get; private set; }
    public WarpDrive? WarpDrive { get; private set; }
    public Deflector.Deflector? Deflector { get; private set; }
    public IAntiNitrineReflector? AntiNitrineReflector { get; private set; }

    public void CrewDead()
    {
        CrewLifeStatus = false;
    }
}