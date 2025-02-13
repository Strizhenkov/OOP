using Npgsql;

namespace Infrastructure.SQLConnection;

#pragma warning disable CA2100
#pragma warning disable CA2000
public class SqlRequest
{
    private const string ConnectionString = "Server=127.0.0.1;Port=5432;UserId=JohnDoe;Password=123;Database=Lab5;";

    private NpgsqlConnection Conn { get; set; } = new NpgsqlConnection(ConnectionString);

    public string GetAllData()
    {
        string sqlRequest = "select " +
                                "json_build_object('Users', json_agg " +
                                    "(json_build_object " +
                                        "('UserId', pu.id, 'UserName', pu.\"name\", 'UserPassword', pu.\"password\", " +
                                            "'UserBalances', (select json_agg " +
                                                " (json_build_object " +
                                                    "('BalanceId', pb.id, 'BalanceUserId', pb.user_id, 'BalanceCash', pb.cash, " +
                                                        "'BalanceTransactions', (select " +
                                                            "json_agg " +
                                                                "(json_build_object " +
                                                                    "( 'CashTransactionId', pt.id, " +
                                                                    "  'CashTransactionBalanceId', pt.balance_id, " +
                                                                    "  'CashTransactionTransactionType', pt.transaction_type, " +
                                                                    "  'CashTransactionCashDelta', pt.cash_delta " +
                                                                    ") " +
                                                                ") " +
                                                        "from \"public.Transaction\" pt where pb.id = pt.balance_id " +
                                                        ") " +
                                                    ") " +
                                                ") " +
                                            "from \"public.Balance\" pb where pb.user_id = pu.id " +
                                        ") " +
                                    ") " +
                                ") " +
                            ") " +
                            "from \"public.User\" pu;";
        Conn.Open();
        var cmd = new NpgsqlCommand(sqlRequest, Conn);
        NpgsqlDataReader reader = cmd.ExecuteReader();
        string? data = null;
        if (reader.Read())
        {
            data = reader[0].ToString();
        }

        Conn.Close();
        return data ?? string.Empty;
    }

    public string InsertWithdrawData(int removedMoney, int moneyObBalance, int balanceId)
    {
        Conn.Open();
        string removeSqlRequest = $"update \"public.Balance\" " +
                                  $"set cash = '{moneyObBalance}' " +
                                  $"where id = '{balanceId}';";
        var cmd = new NpgsqlCommand(removeSqlRequest, Conn);
        cmd.ExecuteReader();
        Conn.Close();

        Conn.Open();
        string transactionSqlRequest = $"insert into \"public.Transaction\" (balance_id, transaction_type, cash_delta) values ('{balanceId}', 1, '{removedMoney}');";
        cmd = new NpgsqlCommand(transactionSqlRequest, Conn);
        cmd.ExecuteReader();
        Conn.Close();

        return "DataBase updated";
    }

    public string InsertPutData(int puttedMoney, int moneyObBalance, int balanceId)
    {
        Conn.Open();
        string removeSqlRequest = $"update \"public.Balance\" " +
                                  $"set cash = '{moneyObBalance}' " +
                                  $"where id = '{balanceId}';";
        var cmd = new NpgsqlCommand(removeSqlRequest, Conn);
        cmd.ExecuteReader();
        Conn.Close();

        Conn.Open();
        string transactionSqlRequest = $"insert into \"public.Transaction\" (balance_id, transaction_type, cash_delta) values ('{balanceId}', 2, '{puttedMoney}');";
        cmd = new NpgsqlCommand(transactionSqlRequest, Conn);
        cmd.ExecuteReader();
        Conn.Close();

        return "DataBase updated";
    }
}


#pragma warning restore CA2000
#pragma warning restore CA2100