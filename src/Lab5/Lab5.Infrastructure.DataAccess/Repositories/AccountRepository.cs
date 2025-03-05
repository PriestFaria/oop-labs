using Itmo.Dev.Platform.Postgres.Connection;
using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Models;
using Npgsql;

namespace Lab5.Infrastructure.DataAccess.Repositories;

public class AccountRepository : IAccountRepository
{
    private readonly IPostgresConnectionProvider _connectionProvider;

    public AccountRepository(IPostgresConnectionProvider connectionProvider)
    {
        _connectionProvider = connectionProvider;
    }

    public Account? GetAccount(long id)
    {
        const string sql = """
                           SELECT account_id, balance FROM accounts WHERE account_id = @AccountId
                           """;

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        using NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        command.Parameters.AddWithValue("@AccountId", id);

        using NpgsqlDataReader reader = command.ExecuteReader();

        if (reader.Read())
        {
            long accountId = reader.GetInt64(0);

            return new Account(accountId);
        }

        return null;
    }

    public long GetBalanceByAccountId(long id)
    {
        const string sql = """
                               SELECT balance FROM accounts WHERE account_id = @AccountId
                           """;

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        using NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        command.Parameters.AddWithValue("@AccountId", id);

        object? commandResult = command.ExecuteScalar();

        return commandResult != null ? (long)commandResult : 0;
    }

    public void Debit(long id, double amount)
    {
        const string sql = @"
            UPDATE accounts SET balance = balance + @Amount WHERE account_id = @AccountId";

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        using NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        command.Parameters.AddWithValue("@AccountId", id);
        command.Parameters.AddWithValue("@Amount", amount);

        command.ExecuteScalar();
    }

    public void Credit(long id, double amount)
    {
        const string sql = """
                                       UPDATE accounts SET balance = balance - @Amount WHERE account_id = @AccountId
                           """;

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        using NpgsqlConnection result = connection.GetAwaiter().GetResult();

        using var command = new NpgsqlCommand(sql, result);
        command.Parameters.AddWithValue("AccountId", id);
        command.Parameters.AddWithValue("Amount", amount);

        command.ExecuteScalar();
    }

    public Account CreateAccount(long id)
    {
        const string accountSql = """
                                  INSERT INTO accounts (account_id, balance) 
                                  VALUES (@AccountId, @Balance);
                                  """;

        Task<NpgsqlConnection> connection = _connectionProvider
            .GetConnectionAsync(default)
            .AsTask();

        using NpgsqlConnection result = connection.GetAwaiter().GetResult();
        using NpgsqlTransaction transaction = result.BeginTransaction();

        try
        {
            using var accountCommand = new NpgsqlCommand(accountSql, result, transaction);
            accountCommand.Parameters.AddWithValue("@AccountId", id);
            accountCommand.Parameters.AddWithValue("@Balance", 0);
            accountCommand.ExecuteNonQuery();

            transaction.Commit();
            return new Account(id);
        }
        catch (PostgresException ex) when (ex.SqlState == "23505")
        {
            Console.WriteLine($"Error: Account with ID {id} already exists.");
            transaction.Rollback();
            throw;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error creating account: {ex.Message}");
            transaction.Rollback();
            throw;
        }
    }
}