using System.Collections.Generic;
using Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

public interface ISpace
{
    double Distance { get; }
    string RequiredFuelType { get; }

    IReadOnlyCollection<IBarrier>? Barriers { get; }
}