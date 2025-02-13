using Newtonsoft.Json;

namespace Application.Models;

public class AuthRequestObject : Jsonable
{
    public AuthRequestObject(string head, string? body)
    {
        Head = head;
        Body = body;
    }

    [JsonProperty("AuthRequestObjectHead")]
    public string? Head { get; set; }
    [JsonProperty("AuthRequestObjectBody")]
    public string? Body { get; set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "AuthRequestObject";
    }

    public override AuthRequestObject? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<AuthRequestObject>(jsonString);
    }
}