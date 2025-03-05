namespace Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

public abstract record ShowResult
{
    private ShowResult() { }

    public sealed record Success : ShowResult;

    public sealed record MessageDoesNotExist : ShowResult;
}