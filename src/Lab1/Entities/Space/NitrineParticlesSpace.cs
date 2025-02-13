using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class NitrineParticlesSpace : ISpace
{
    public NitrineParticlesSpace(double distance, IReadOnlyCollection<INitrineParticlesSpaceBarriers>? barriers)
    {
        Distance = distance;
        Barriers = barriers;
    }

    public string RequiredFuelType { get; private set; } = "PlasmaFuel";
    public IReadOnlyCollection<IBarrier>? Barriers { get; }
    public double Distance { get; private set; }
}