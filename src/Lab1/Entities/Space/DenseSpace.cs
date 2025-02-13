using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public class DenseSpace : ISpace
{
    public DenseSpace(double distance, IReadOnlyCollection<IDenseSpaceBarriers>? barriers)
    {
        Distance = distance;
        Barriers = barriers;
    }

    public string RequiredFuelType { get; } = "MatterFuel";
    public IReadOnlyCollection<IBarrier>? Barriers { get; }
    public double Distance { get; private set; }
}