using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Login;

public class LoginScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly CurrentAccountService _currentAccountService;

    public LoginScenarioProvider(
        IAccountService service, CurrentAccountService currentAccountService)
    {
        _service = service;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.CurrentAccount == null)
        {
            scenario = new LoginScenario(_service, _currentAccountService);
            return true;
        }

        scenario = null;
        return false;
    }
}