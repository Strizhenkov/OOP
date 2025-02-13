using Newtonsoft.Json;

namespace Application.Models;

#pragma warning disable SA1300
#pragma warning disable IDE2000
public class Balances : Jsonable
{
    public Balances(IList<Balance?> newBalancesList)
    {
        balances = newBalancesList;
    }

    [JsonProperty("Balances")]
    public IList<Balance?> balances { get; private set; } = new List<Balance?>();

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "balances";
    }

    public override Balances? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Balances>(jsonString);
    }
}

#pragma warning restore IDE2000
#pragma warning restore SA1300