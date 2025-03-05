using Lab5.Application.Models;

namespace Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    LoginResult Login(long id);

    double GetBalance(long id);

    OperationResult Credit(double amount, long id);

    OperationResult Debit(double amount, long id);

    IEnumerable<Operation> GetOperations(long id);

    long Create(long id);
}