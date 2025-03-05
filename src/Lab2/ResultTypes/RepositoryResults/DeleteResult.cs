namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

public class DeleteResult<T>
{
    public class EntityDoesNotExist : DeleteResult<T> { }

    public class Success : DeleteResult<T> { }
}