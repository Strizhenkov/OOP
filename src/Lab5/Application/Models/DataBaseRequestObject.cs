using Newtonsoft.Json;

namespace Application.Models;

public class DataBaseRequestObject : Jsonable
{
    public DataBaseRequestObject(string head, string? body)
    {
        Head = head;
        Body = body;
    }

    [JsonProperty("DataBaseRequestObjectHead")]
    public string? Head { get; set; }
    [JsonProperty("DataBaseRequestObjectBody")]
    public string? Body { get; set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "DataBaseRequestObject";
    }

    public override DataBaseRequestObject? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<DataBaseRequestObject>(jsonString);
    }
}