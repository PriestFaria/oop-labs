using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Repositories;

public interface IRepository<T>
{
    IList<T> List { get; }

    FindResult<T> Find(Guid id);

    AddResult<T> Add(T item);

    DeleteResult<T> Delete(Guid id);
}