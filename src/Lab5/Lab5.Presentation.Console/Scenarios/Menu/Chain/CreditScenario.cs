using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Menu.Chain;

public class CreditScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount _current;
    private IScenario? _nextScenario;

    public CreditScenario(IAccountService accountService, CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Credit";

    public void Run()
    {
        double amount = AnsiConsole.Ask<double>("How much would you like to credit?\n");

        _accountService.Credit(amount, _current.Id);

        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}