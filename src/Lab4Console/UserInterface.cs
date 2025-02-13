using Itmo.ObjectOrientedProgramming.Lab4.CommandOperator;
using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;

namespace Lab4Console;

public class UserInterface
{
    private bool ConnectStatus { get; set; }
    public void Start()
    {
        var commandOperator = new CommandOperatorWindows();
        var commandParser = new TypeCommandParser();

        while (!ConnectStatus)
        {
            Console.WriteLine("Input connect command");
            string? data = Console.ReadLine();
            ICommand command = commandParser.Execute(data);
            string result = commandOperator.CommandRun(command);
            if (result == "Connect")
                ConnectStatus = true;
            Console.WriteLine(result);
        }

        while (ConnectStatus)
        {
            Console.WriteLine("Input command");
            string? data = Console.ReadLine();
            ICommand command = commandParser.Execute(data);
            string result = commandOperator.CommandRun(command);
            if (result == "Disconnect")
                ConnectStatus = false;
            Console.WriteLine(result);
        }
    }
}