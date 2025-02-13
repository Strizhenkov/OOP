using Newtonsoft.Json;

namespace Application.Models;

public class CashTransaction : Jsonable
{
    public CashTransaction(int id, int balanceId, int transactionType, int cashDelta)
    {
        Id = id;
        BalanceId = balanceId;
        TransactionType = transactionType;
        CashDelta = cashDelta;
    }

    public CashTransaction()
    {
    }

    [JsonProperty("CashTransactionId")]
    public int Id { get; private set; }
    [JsonProperty("CashTransactionBalanceId")]
    public int BalanceId { get; private set; }
    [JsonProperty("CashTransactionTransactionType")]
    public int TransactionType { get; private set; }
    [JsonProperty("CashTransactionCashDelta")]
    public int CashDelta { get; private set; }

    public override string Serial()
    {
        return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

    public override string ToString()
    {
        return "transaction";
    }

    public override CashTransaction? Deserial(string jsonString)
    {
        return JsonConvert.DeserializeObject<CashTransaction>(jsonString);
    }
}