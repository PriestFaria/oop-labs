namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record EditSubjectResult
{
    private EditSubjectResult() { }

    public sealed record Success : EditSubjectResult;

    public sealed record AlreadyExisting : EditSubjectResult;

    public sealed record UserHasNoPermission : EditSubjectResult;

    public sealed record ElementNotExisting : EditSubjectResult;
}