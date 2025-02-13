using Newtonsoft.Json;

namespace Application.Models;

public class ActionRequestObject : Jsonable
{
    public ActionRequestObject(string head, string? body)
    {
        Head = head;
        Body = body;
    }

    [JsonProperty("ActionRequestObjectHead")]
    public string? Head { get; set; }
    [JsonProperty("ActionRequestObjectBody")]
    public string? Body { get; set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "ActionRequestObject";
    }

    public override ActionRequestObject? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<ActionRequestObject>(jsonString);
    }
}