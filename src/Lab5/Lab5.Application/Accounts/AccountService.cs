using Lab5.Application.Abstractions.Repositories;
using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models;

namespace Lab5.Application.Accounts;

public class AccountService : IAccountService
{
    private readonly IAccountRepository _accountRepository;
    private readonly IOperationsRepository _operationsRepository;

    public AccountService(
        IAccountRepository accountRepository,
        IOperationsRepository operationsRepository)
    {
        _accountRepository = accountRepository;
        _operationsRepository = operationsRepository;
    }

    public LoginResult Login(long id)
    {
        Account? account = _accountRepository.GetAccount(id);

        if (account == null)
        {
            return new LoginResult.NotFound();
        }

        return new LoginResult.Success(account.Id);
    }

    public double GetBalance(long id)
    {
        return _accountRepository.GetBalanceByAccountId(id);
    }

    public IEnumerable<Operation> GetOperations(long id)
    {
        return _operationsRepository.GetOperationsByAccount(id);
    }

    public OperationResult Credit(double amount, long id)
    {
        double balance = _accountRepository.GetBalanceByAccountId(id);

        if (balance < amount) return new OperationResult.Failure();

        _operationsRepository.AddOperation(id, -amount);
        _accountRepository.Credit(id, amount);
        return new OperationResult.Success();
    }

    public OperationResult Debit(double amount, long id)
    {
        _operationsRepository.AddOperation(id, amount);

        _accountRepository.Debit(id, amount);
        Console.WriteLine(amount);
        return new OperationResult.Success();
    }

    public long Create(long id)
    {
        return _accountRepository.CreateAccount(id).Id;
    }
}