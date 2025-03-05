namespace Lab5.Application.Abstractions.Auth;

public abstract record ValidationResult
{
    private ValidationResult() { }

    public sealed record Success : ValidationResult;

    public sealed record TimedOut : ValidationResult;

    public sealed record NotFound : ValidationResult;
}