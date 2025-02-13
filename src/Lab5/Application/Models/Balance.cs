using Newtonsoft.Json;

namespace Application.Models;

public class Balance : Jsonable
{
    public Balance(int id, int userId, int cash, IList<CashTransaction> transactions)
    {
        Id = id;
        UserId = userId;
        Cash = cash;
        Transactions = transactions;
    }

    public Balance()
    {
    }

    [JsonProperty("BalanceId")]
    public int Id { get; private set; }
    [JsonProperty("BalanceUserId")]
    public int UserId { get; private set; }
    [JsonProperty("BalanceCash")]
    public int Cash { get; private set; }
    [JsonProperty("BalanceTransactions")]
    public IList<CashTransaction>? Transactions { get; private set; }
    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "balance";
    }

    public override Balance? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<Balance>(jsonString);
    }
}