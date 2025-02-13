using Itmo.ObjectOrientedProgramming.Lab1.Entities.AntiNitrineReflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class Valcas : IShip
{
    public Valcas(PulseDriveE pulseDrive, WarpDriveGamma warpDrive)
    {
        CrewLifeStatus = true;
        Hull = new HullClass2();
        PulseDrive = pulseDrive;
        WarpDrive = warpDrive;
        Deflector = new DeflectorClass1();
    }

    public bool CrewLifeStatus { get; private set; }
    public Hull.Hull Hull { get; private set; }
    public PulseDrive PulseDrive { get; private set; }
    public WarpDrive? WarpDrive { get; private set; }
    public Deflector.Deflector? Deflector { get; protected set; }
    public IAntiNitrineReflector? AntiNitrineReflector { get; private set; }

    public void CrewDead()
    {
        CrewLifeStatus = false;
    }
}