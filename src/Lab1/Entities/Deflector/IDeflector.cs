namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public interface IDeflector
{
    public void DeflectorOff();
    public void CountDamage(int healthDamage);
}

public class Deflector : IDeflector
{
    public int HealthPoints { get; protected set; }
    public bool Active { get; protected set; } = true;
    public void DeflectorOff()
    {
        Active = false;
        HealthPoints = 0;
    }

    public virtual void CountDamage(int healthDamage)
    {
        HealthPoints -= healthDamage;
        if (HealthPoints == 0)
            DeflectorOff();
    }
}