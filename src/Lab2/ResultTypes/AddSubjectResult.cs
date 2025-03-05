namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record AddSubjectResult
{
    private AddSubjectResult() { }

    public sealed record Success : AddSubjectResult;

    public sealed record AlreadyExisting : AddSubjectResult;

    public sealed record UserHasNoPermission : AddSubjectResult;
}