using Lab5.Application.Models;

namespace Lab5.Application.Abstractions.Repositories;

public interface IAccountRepository
{
    Account CreateAccount(long id);

    Account? GetAccount(long id);

    long GetBalanceByAccountId(long id);

    void Debit(long id, double amount);

    void Credit(long id, double amount);
}