using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenario : IScenario
{
    private readonly IAccountService _accountService;
    private readonly CurrentAccountService _currentAccountService;

    public LoginScenario(IAccountService accountService, CurrentAccountService currentAccountService)
    {
        _accountService = accountService;
        _currentAccountService = currentAccountService;
    }

    public string Name => "Login";

    public void Run()
    {
        long account = AnsiConsole.Ask<long>("Enter your [green]ID[/]");

        LoginResult result = _accountService.Login(account);

        switch (result)
        {
            case LoginResult.Success success:
                _currentAccountService.CurrentAccount = new CurrentAccount(account);

                if (_currentAccountService.IsAdmin())
                {
                    AnsiConsole.MarkupLine($"Logged in as [blue]Admin[/]");
                    AnsiConsole.Console.Input.ReadKey(false);
                }

                break;

            case LoginResult.NotFound:
                AnsiConsole.MarkupLine("[red]Account not found.[/]");
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(result));
        }
    }

    public void SetNext(IScenario scenario)
    {
        throw new NotImplementedException();
    }
}