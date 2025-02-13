using Itmo.ObjectOrientedProgramming.Lab1.Entities.AntiNitrineReflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Shuttle : IShip
{
    public Shuttle(PulseDriveC pulseDrive)
    {
        CrewLifeStatus = true;
        Hull = new HullClass1();
        PulseDrive = pulseDrive;
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