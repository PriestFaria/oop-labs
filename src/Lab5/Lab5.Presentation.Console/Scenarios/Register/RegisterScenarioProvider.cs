using Lab5.Application.Contracts.Accounts;
using Lab5.Presentation.Console.CurrentAccounts;
using System.Diagnostics.CodeAnalysis;

namespace Lab5.Presentation.Console.Scenarios.Register;

public class RegisterScenarioProvider : IScenarioProvider
{
    private readonly IAccountService _service;
    private readonly CurrentAccountService _currentAccountService;

    public RegisterScenarioProvider(
        IAccountService service,
        CurrentAccountService currentAccountService)
    {
        _service = service;
        _currentAccountService = currentAccountService;
    }

    public bool TryGetScenario(
        [NotNullWhen(true)] out IScenario? scenario)
    {
        if (_currentAccountService.CurrentAccount == null)
        {
            scenario = new RegisterScenario(_service);
            return true;
        }

        scenario = null;
        return false;
    }
}