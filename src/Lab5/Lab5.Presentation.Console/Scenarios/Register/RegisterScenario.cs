using Lab5.Application.Contracts.Accounts;
using Spectre.Console;

namespace Lab5.Presentation.Console.Scenarios.Register;

public class RegisterScenario : IScenario
{
    private readonly IAccountService _accountService;

    public RegisterScenario(IAccountService accountService)
    {
        _accountService = accountService;
    }

    public string Name => "Register";

    public void Run()
    {
        long id1 = AnsiConsole.Ask<long>("Enter your [green]ID[/]: ");
        long id2 = AnsiConsole.Ask<long>("Re-enter your [green]ID[/]: ");

        if (id1 != id2)
        {
            AnsiConsole.MarkupLine("[red]IDs do not match. Please try again.[/]");
            Run();
            return;
        }

        long id = _accountService.Create(id1);
        AnsiConsole.MarkupLine($"[green]Account created successfully! Your ID: {id}[/]");
    }

    public void SetNext(IScenario scenario)
    {
        throw new NotImplementedException();
    }
}