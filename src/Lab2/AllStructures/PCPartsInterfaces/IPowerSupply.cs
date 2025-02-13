namespace Itmo.ObjectOrientedProgramming.Lab2.AllStructures.PcPartsInterfaces;

public interface IPowerSupply
{
    public int MaxUsedPower { get; protected set; }
    IPowerSupply SetMaxUsedPower(int maxUsedPower);

    IPowerSupply Builder(int maxUsedPower);
}

public class PowerSupply : IPowerSupply
{
    public int MaxUsedPower { get; set; }

    public IPowerSupply Builder(int maxUsedPower)
    {
        return new PowerSupply().SetMaxUsedPower(maxUsedPower);
    }

    public IPowerSupply SetMaxUsedPower(int maxUsedPower)
    {
        MaxUsedPower = maxUsedPower;
        return this;
    }
}