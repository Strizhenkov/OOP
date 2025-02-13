using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class BasicSpace : ISpace
{
    public BasicSpace(double distance, IReadOnlyCollection<IBasicSpaceBarriers>? barriers)
    {
        Distance = distance;
        Barriers = barriers;
    }

    public string RequiredFuelType { get; private set; } = "PlasmaFuel";
    public IReadOnlyCollection<IBarrier>? Barriers { get; }
    public double Distance { get; private set; }
}