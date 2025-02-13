namespace Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

public class Message
{
    public Message(int id, string head, string body, int importance)
    {
        Id = id;
        IsVisible = false;
        Importance = importance;
        Head = head;
        Body = body;
    }

    public int Id { get; private set; }
    public int Importance { get; private set; }
    public bool IsVisible { get; internal set; }
    public string Head { get; private set; }
    public string Body { get; private set; }

    public override string ToString()
    {
        return $"{Head} \n {Body} \n";
    }
}