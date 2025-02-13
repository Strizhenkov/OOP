using Itmo.ObjectOrientedProgramming.Lab1.Entities.Space;

namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Barrier;

public class Asteroid : IBasicSpaceBarriers
{
    public int Damage { get; private set; } = 1;
}