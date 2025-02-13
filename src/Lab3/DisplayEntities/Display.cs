using Itmo.ObjectOrientedProgramming.Lab3.MessageEntities;

namespace Itmo.ObjectOrientedProgramming.Lab3.DisplayEntities;

public class Display : IDisplay
{
    public Display(int id)
    {
        Id = id;
        LastMessage = string.Empty;
        Driver = new DisplayDriver();
    }

    public DisplayDriver Driver { get; private set; }
    public int Id { get; private set; }
    public string LastMessage { get; private set; }

    public void GetMessage(Message? message)
    {
        Driver.Clear();
        Driver.Print(message != null ? message.ToString() : "Empty Message");
    }
}