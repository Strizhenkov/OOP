using Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.PulseDrive;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Drives.WarpDrive;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Ship;

public class PhotonValcas : Valcas
{
    public PhotonValcas(PulseDriveE pulseDrive, WarpDriveGamma warpDrive)
        : base(pulseDrive, warpDrive)
    {
        Deflector = new PhotonDeflectorClass1();
    }
}