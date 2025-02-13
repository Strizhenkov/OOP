using Newtonsoft.Json;

namespace Application.Models;

#pragma warning disable SA1300
#pragma warning disable IDE2000
public class Users : Jsonable
{
    [JsonProperty("Users")]
    public IList<User?> users { get; private set; } = new List<User?>();

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "users";
    }

    public override Users? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Users>(jsonString);
    }

    public bool CheckUser(string userData)
    {
        return users.Any(e => e != null && e.ToString() == userData);
    }

    public User? GetUser(string userPassword)
    {
        return users.ToList().Find(e => e != null && e.ToString() == userPassword);
    }
}

#pragma warning restore IDE2000
#pragma warning restore SA1300