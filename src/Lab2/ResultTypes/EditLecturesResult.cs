namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;

public abstract record EditLecturesResult
{
    private EditLecturesResult() { }

    public sealed record Success : EditLecturesResult;

    public sealed record AlreadyExisting : EditLecturesResult;

    public sealed record UserHasNoPermission : EditLecturesResult;
}