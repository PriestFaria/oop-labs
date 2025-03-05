namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record ChangeMessageStatusResult
{
    private ChangeMessageStatusResult() { }

    public sealed record Success : ChangeMessageStatusResult;

    public sealed record MessageDoesNotExist : ChangeMessageStatusResult;

    public sealed record AlreadyRead : ChangeMessageStatusResult;
}