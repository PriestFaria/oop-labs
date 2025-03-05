using Lab5.Presentation.Console.CurrentAccounts;

namespace Lab5.Presentation.Console.Scenarios.Menu.Chain;

public class LogoutScenario : IScenario
{
    private readonly CurrentAccountService _currentAccountService;
    private IScenario? _nextScenario;

    public LogoutScenario(CurrentAccountService currentAccountService)
    {
        _currentAccountService = currentAccountService;
    }

    public string Name => "Logout";

    public void Run()
    {
        _currentAccountService.CurrentAccount = null;
        _nextScenario?.Run();
    }

    public void SetNext(IScenario scenario)
    {
        _nextScenario = scenario;
    }
}