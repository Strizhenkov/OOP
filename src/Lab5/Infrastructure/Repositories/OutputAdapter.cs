using Application.Abstractions;
using Application.Models;
using Infrastructure.SQLConnection;

namespace Infrastructure.Repositories;

public class OutputAdapter : IOutputPort
{
    public string GetData()
    {
        return new SqlRequest().GetAllData();
    }

    public string Post(DataBaseRequestObject data)
    {
        int value = 0;
        int balanceId = 0;
        int valueOnBalance = 0;
        if (data?.Body == null) return "Empty request";
        bool balanceIdParseResult = data?.Body != null && int.TryParse(data.Body.Split(" ").First(), out balanceId);
        bool valueParseResult = data?.Body != null && int.TryParse(data.Body.Split(" ").SkipLast(1).Last(), out value);
        bool valueOnBalanceParseResult = data?.Body != null && int.TryParse(data.Body.Split(" ").Last(), out valueOnBalance);
        if (!balanceIdParseResult && !valueParseResult && !valueOnBalanceParseResult) return "Wrong Value";
        return data?.Head switch
        {
            "Withdraw" => new SqlRequest().InsertWithdrawData(value, valueOnBalance, balanceId),
            "Put" => new SqlRequest().InsertPutData(value, valueOnBalance, balanceId),
            _ => "Wrong Request",
        };
    }
}