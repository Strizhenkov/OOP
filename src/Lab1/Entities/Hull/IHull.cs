namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Hull;

public interface IHull
{
    public void CountDamage(int damage);
}

public class Hull : IHull
{
    public int HealthPoints { get; protected set; }
    public void CountDamage(int damage)
    {
        HealthPoints -= damage;
    }
}