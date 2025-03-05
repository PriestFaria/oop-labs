using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using Lab5.Presentation.Console.Scenarios.Menu.Chain;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Menu;

public class MenuScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly CurrentAccountService _currentAccountService;

    public MenuScenarioProvider(
        IAccountService service, CurrentAccountService currentAccountService)
    {
        _service = service;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.CurrentAccount != null)
        {
            scenario = GetScenarioChain(_currentAccountService.CurrentAccount);
            return true;
        }

        scenario = null;
        return false;
    }

#pragma warning disable CA1859
    private IScenario GetScenarioChain(CurrentAccount account)
#pragma warning restore CA1859
    {
        var entry = new MenuScenario(_service, account);

        var credit = new CreditScenario(_service, account);
        credit.SetNext(entry);

        var debit = new DebitScenario(_service, account);
        debit.SetNext(entry);

        var operations = new RecentOperationsScenario(_service, account);
        operations.SetNext(entry);

        var logout = new LogoutScenario(_currentAccountService);

        entry.SetNext(debit);
        entry.SetNext(credit);
        entry.SetNext(operations);
        entry.SetNext(logout);

        return entry;
    }
}