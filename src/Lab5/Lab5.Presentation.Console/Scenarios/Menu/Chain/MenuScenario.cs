using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using Spectre.Console;
using System.Text;

namespace Lab5.Presentation.Console.Scenarios.Menu.Chain;

public class MenuScenario : IScenario
{
    private readonly List<IScenario> _scenarios = new();
    private readonly IAccountService _accountService;
    private readonly CurrentAccount _current;

    public MenuScenario(IAccountService accountService, CurrentAccount current)
    {
        _accountService = accountService;
        _current = current;
    }

    public string Name => "Menu";

    public void Run()
    {
        var sb = new StringBuilder();
        sb.Append("Current Balance: ");
        sb.Append(_accountService.GetBalance(_current.Id));

        SelectionPrompt<IScenario> selector = new SelectionPrompt<IScenario>()
            .Title(sb.ToString())
            .AddChoices(_scenarios)
            .UseConverter(x => x.Name);

        IScenario scenario = AnsiConsole.Prompt(selector);
        scenario.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _scenarios.Add(scenario);
    }
}