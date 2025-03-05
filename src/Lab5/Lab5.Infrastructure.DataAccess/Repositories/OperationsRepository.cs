using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class OperationsRepository : IOperationsRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public OperationsRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public IEnumerable<Operation> GetOperationsByAccount(long id)
    {
        const string sql = """
                           SELECT * FROM operations WHERE account_id = :AccountId;
                           """;

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        NpgsqlConnection result = connection.GetAwaiter().GetResult();

        var operations = new List<Operation>();

        using (var command = new NpgsqlCommand(sql, result))
        {
            command.Parameters.AddWithValue("AccountId", id);

            using NpgsqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                var operation = new Operation((long)reader["account_id"], (double)reader["amount"]);

                operations.Add(operation);
            }
        }

        return operations;
    }

    public void AddOperation(long id, double amount)
    {
        const string sql = """
                           INSERT INTO operations (account_id, amount) 
                           VALUES (:AccountID, :Amount) 
                           """;

        using Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        command.Parameters.AddWithValue("AccountId", id);
        command.Parameters.AddWithValue("Amount", amount);

        command.ExecuteScalar();
    }
}