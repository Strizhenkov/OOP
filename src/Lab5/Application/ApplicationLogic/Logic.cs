using Application.Abstractions;
using Application.Models;

namespace Application.ApplicationLogic;

public enum AuthStatus
{
    None,
    User,
    Admin,
}

public class Logic
{
    public Logic(IOutputPort outputPort)
    {
        Adapter = outputPort;
    }

    public IOutputPort Adapter { get; set; }
    private AuthStatus UserStatus { get; set; } = AuthStatus.None;
    private User? CurrentUser { get; set; }
    private string AdminKey { get; set; } = "123";

    public string AuthOperator(AuthRequestObject actionRequestObject)
    {
        if (actionRequestObject?.Body == "Admin " + AdminKey)
        {
            UserStatus = AuthStatus.Admin;
            return "Admin auth";
        }
        else
        {
            string ans = Adapter.GetData();
            Users? users = new Users().Deserial(ans);

            string? inputData = string.Empty;
            if (actionRequestObject?.Body != null)
            {
                inputData = actionRequestObject.Body;
            }

            bool result = users != null && users.CheckUser(inputData);

            if (!result)
            {
                return "Wrong auth";
            }

            UserStatus = AuthStatus.User;
            CurrentUser = users?.GetUser(inputData);
            if (CurrentUser != null) return "UserId " + CurrentUser.Id + " auth";
        }

        return "Wrong auth";
    }

    public string RequestSelectOperator(ActionRequestObject actionRequestObject)
    {
        return actionRequestObject?.Head switch
        {
            "GET" => RequestGetOperator(actionRequestObject),
            "POST" => RequestPostOperator(actionRequestObject),
            _ => "Wrong request",
        };
    }

    public string RequestGetOperator(ActionRequestObject actionRequestObject)
    {
        switch (actionRequestObject?.Body)
        {
            case "All":
                if (CurrentUser != null) return new Balances(CurrentUser.Balances).Serial();
                break;
            default:
                bool result = int.TryParse(actionRequestObject?.Body, out int balanceId);
                if (!result)
                {
                    return "Wrong request information";
                }

                if (CurrentUser != null && !CurrentUser.CheckBalanceContain(balanceId))
                {
                    return "This balance not your balance";
                }

                #pragma warning disable SK1200
                if (CurrentUser != null) return CurrentUser.GetBalance(balanceId)!.Serial();
                #pragma warning restore SK1200
                break;
        }

        return "Wrong request information";
    }

    public string RequestPostOperator(ActionRequestObject actionRequestObject)
    {
        int operationId = 0;
        int balanceId = 0;
        int value = 0;
        if (actionRequestObject?.Body?.Split(" ").Length != 3)
        {
            return "Wrong Argument Count";
        }

        bool result = actionRequestObject?.Body != null && int.TryParse(actionRequestObject.Body.Split(" ").First(), out operationId);
        if (!result && operationId != 0)
        {
            return "Wrong Operation";
        }

        result = actionRequestObject?.Body != null && int.TryParse(actionRequestObject.Body.Split(" ").Skip(1).First(), out balanceId);
        if (!result && balanceId > 0)
        {
            return "Wrong BalanceId";
        }

        result = actionRequestObject?.Body != null && int.TryParse(actionRequestObject.Body.Split(" ").Last(), out value);
        if (!result && value > 0)
        {
            return "Wrong value";
        }

        if (CurrentUser != null && !CurrentUser.CheckBalanceContain(balanceId))
        {
            return "This balance not your balance";
        }

        #pragma warning disable SK1200
        int? balanceCash = CurrentUser?.GetBalance(balanceId)!.Cash;
        int cashDelta = 0;
        bool valueOnBalanceParseResult = actionRequestObject?.Body != null && int.TryParse(actionRequestObject.Body.Split(" ").Last(), out cashDelta);
        if (!valueOnBalanceParseResult) return "Value must be number";
        var dataBaseRequestObject = new DataBaseRequestObject(string.Empty, string.Join(" ", actionRequestObject?.Body.Split(" ").Skip(1)!));

        switch (operationId)
        {
            case 1:
                if (CurrentUser != null && value > CurrentUser.GetBalance(balanceId)!.Cash)
                    return "You have not enough money on this balance";
                dataBaseRequestObject.Head = "Withdraw";
                dataBaseRequestObject.Body += " " + (balanceCash - cashDelta);
                Adapter.Post(dataBaseRequestObject!);
                UpdateData();
                return "Action finished";
            case 2:
                dataBaseRequestObject.Head = "Put";
                dataBaseRequestObject.Body += " " + (balanceCash + cashDelta);
                Adapter.Post(dataBaseRequestObject!);
                UpdateData();
                return "Action finished";
            default:
                return "Wrong command";
        }
        #pragma warning restore SK1200
    }

    private void UpdateData()
    {
        if (CurrentUser == null) return;
        var copyDataUser = new User(0, CurrentUser.Name, CurrentUser.Password, new List<Balance?>());

        string ans = Adapter.GetData();
        Users? users = new Users().Deserial(ans);

        if (users == null) return;
        CurrentUser = users.GetUser(copyDataUser.Name + " " + copyDataUser.Password);
    }
}