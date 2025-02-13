using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

public class Meteorite : IBasicSpaceBarriers
{
    public int Damage { get; private set; } = 4;
}