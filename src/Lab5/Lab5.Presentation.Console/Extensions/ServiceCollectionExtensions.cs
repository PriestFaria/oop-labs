using Lab5.Presentation.Console.CurrentAccounts;
using Lab5.Presentation.Console.Scenarios.Login;
using Lab5.Presentation.Console.Scenarios.Menu;
using Lab5.Presentation.Console.Scenarios.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Lab5.Presentation.Console.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPresentationConsole(this IServiceCollection collection)
    {
        collection.AddScoped<ScenarioRunner>();

        collection.AddScoped<IScenarioProvider, LoginScenarioProvider>();
        collection.AddScoped<IScenarioProvider, RegisterScenarioProvider>();
        collection.AddScoped<IScenarioProvider, MenuScenarioProvider>();
        collection.AddScoped<CurrentAccountService>();

        return collection;
    }
}