namespace Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

public class FindResult<T>
{
    public T? Value { get; }

    public FindResult(T? value)
    {
        Value = value;
    }

    public class EntityDoesNotExist : FindResult<T>
    {
        public EntityDoesNotExist(T? value) : base(value) { }
    }

    public class Success : FindResult<T>
    {
        public Success(T? value) : base(value) { }
    }
}