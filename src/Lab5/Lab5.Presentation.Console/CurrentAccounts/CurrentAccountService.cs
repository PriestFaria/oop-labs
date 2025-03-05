namespace Lab5.Presentation.Console.CurrentAccounts;

public class CurrentAccountService
{
    public CurrentAccounts.CurrentAccount? CurrentAccount { get; set; }

    public bool IsAdmin()
    {
        return CurrentAccount?.Id == 1;
    }
}