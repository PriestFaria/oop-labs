using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects;

public class SubjectRepository : IRepository<ISubject>
{
    public IList<ISubject> List { get; }

    public SubjectRepository()
    {
        List = new List<ISubject>();
    }

    public AddResult<ISubject> Add(ISubject item)
    {
        if (Find(item.Id) is FindResult<ISubject>.EntityDoesNotExist)
        {
            List.Add(item);
            return new AddResult<ISubject>.Success();
        }

        return new AddResult<ISubject>.EntityAlreadyExists();
    }

    public FindResult<ISubject> Find(Guid id)
    {
        ISubject? subject = List.FirstOrDefault(subject => subject.Id == id);
        if (subject == null)
        {
            return new FindResult<ISubject>.EntityDoesNotExist(subject);
        }

        return new FindResult<ISubject>.Success(subject);
    }

    public DeleteResult<ISubject> Delete(Guid id)
    {
        foreach (ISubject subject in List)
        {
            if (subject.Id == id)
            {
                List.RemoveAt(List.IndexOf(subject));
                return new DeleteResult<ISubject>.Success();
            }
        }

        return new DeleteResult<ISubject>.EntityDoesNotExist();
    }
}