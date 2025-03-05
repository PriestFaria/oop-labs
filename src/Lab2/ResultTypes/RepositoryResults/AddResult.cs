namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

public class AddResult<T>
{
    public class EntityAlreadyExists : AddResult<T> { }

    public class Success : AddResult<T> { }
}