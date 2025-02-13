using Application.Contracts;
using Application.Models;
using Presentation.Scenarios;

namespace Presentation.UserInterface;

#pragma warning disable CA1859
public class Ui
{
    public Ui(InputAdapter inputPort)
    {
        Adapter = inputPort;
    }

    private string AuthResponse { get; set; } = "Wrong auth";
    private IInputPort Adapter { get; set; }

    public void Start()
    {
        while (AuthResponse.Substring(0, 10) == "Wrong auth")
        {
            Console.WriteLine("Write your username and password");
            string? authRequest = Console.ReadLine();
            var request = new AuthRequestObject("GET", authRequest);
            AuthResponse = Adapter.Auth(request);
            Console.WriteLine(AuthResponse);
        }

        while (true)
        {
            Console.WriteLine("Select operation: 1) Get score info. 2) Do some actions with your score. ");
            string? typeRequest = Console.ReadLine();
            string ans;
            switch (typeRequest)
            {
                case "1":
                    Console.WriteLine("Select show object: 1) All (Show information about all your balances) 2) ID (ID - one of your balanceId)");
                    string? bodyRequest = Console.ReadLine();
                    var getRequest = new ActionRequestObject("GET", bodyRequest);
                    ans = Adapter.Request(getRequest);
                    Console.WriteLine(ans);
                    break;
                case "2":
                    Console.WriteLine("Select operation: 1) Withdraw 2) Put");
                    string? actionRequest = Console.ReadLine();
                    Console.WriteLine("Write your balanceId and cash value");
                    string? resourceRequest = Console.ReadLine();
                    var postRequest = new ActionRequestObject("POST", actionRequest + " " + resourceRequest);
                    ans = Adapter.Request(postRequest);
                    Console.WriteLine(ans);
                    break;
                default:
                    Console.WriteLine("Wrong operation format");
                    break;
            }
        }
    }
}

#pragma warning restore CA1859