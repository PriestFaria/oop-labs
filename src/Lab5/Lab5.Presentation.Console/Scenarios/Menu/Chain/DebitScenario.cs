using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Menu.Chain;

public class DebitScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount _current;
    private IScenario? _nextScenario;

    public DebitScenario(IAccountService accountService, CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Debit";

    public void Run()
    {
        double amount = AnsiConsole.Ask<double>("How much would you like to debit\n");

        _accountService.Debit(amount, _current.Id);

        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}