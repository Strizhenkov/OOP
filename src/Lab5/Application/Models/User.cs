using Newtonsoft.Json;

namespace Application.Models;

public class User : Jsonable
{
    public User(int id, string? name, string? password, IList<Balance?> balances)
    {
        Id = id;
        Name = name;
        Password = password;
        Balances = balances;
    }

    [JsonProperty("UserId")]
    public int Id { get; private set; }
    [JsonProperty("UserName")]
    public string? Name { get; private set; }
    [JsonProperty("UserPassword")]
    public string? Password { get; private set; }
    [JsonProperty("UserBalances")]
    public IList<Balance?> Balances { get; private set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return $"{Name} {Password}";
    }

    public override User? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<User>(jsonString);
    }

    public bool CheckBalanceContain(int id)
    {
        return Balances.Any(balance => balance != null && balance.Id == id);
    }

    public Balance? GetBalance(int id)
    {
        return Balances.First(balance => balance != null && balance.Id == id);
    }
}