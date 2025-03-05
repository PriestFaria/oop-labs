namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record EditLabResult
{
    private EditLabResult() { }

    public sealed record Success : EditLabResult;

    public sealed record UserHasNoPermission : EditLabResult;
}