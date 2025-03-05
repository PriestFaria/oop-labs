using Lab5.Application.Contracts.Accounts;
using Lab5.Application.Models;
using Lab5.Presentation.Console.CurrentAccounts;
using Spectre.Console;
using System.Globalization;
using System.Text;

namespace Lab5.Presentation.Console.Scenarios.Menu.Chain;

public class RecentOperationsScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccount _current;
    private IScenario? _nextScenario;

    public RecentOperationsScenario(IAccountService accountService, CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Recent Operations";

    public void Run()
    {
        IEnumerable<Operation> operations = _accountService.GetOperations(_current.Id);

        AnsiConsole.WriteLine("Recent Operations:");

        var sb = new StringBuilder();

        foreach (Operation operation in operations)
        {
            sb.AppendLine(operation.Amount.ToString(CultureInfo.CurrentCulture));
        }

        AnsiConsole.WriteLine(sb.ToString());

        AnsiConsole.Console.Input.ReadKey(false);
        AnsiConsole.Clear();
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}