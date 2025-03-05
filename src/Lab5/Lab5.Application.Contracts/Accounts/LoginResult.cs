namespace Lab5.Application.Contracts.Accounts;

public abstract record LoginResult
{
    private LoginResult() { }

    public sealed record Success(long Id) : LoginResult;

    public sealed record NotFound : LoginResult;
}