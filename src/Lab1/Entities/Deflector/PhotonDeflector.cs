namespace Itmo.ObjectOrientedProgramming.Lab1.Entities.Deflector;

public class PhotonDeflector : Deflector
{
    public int PhotonHealth { get; protected set; } = 3;

    public override void CountDamage(int healthDamage)
    {
        if (healthDamage != 0)
        {
            HealthPoints -= healthDamage;
            if (HealthPoints == 0)
                DeflectorOff();
        }
        else
        {
            GetPhotonDamage();
        }
    }

    public void GetPhotonDamage()
    {
        PhotonHealth -= 1;
    }
}