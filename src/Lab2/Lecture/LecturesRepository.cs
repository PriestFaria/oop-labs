using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class LecturesRepository : IRepository<ILectures>
{
    public IList<ILectures> List { get; }

    public LecturesRepository()
    {
        List = new List<ILectures>();
    }

    public AddResult<ILectures> Add(ILectures item)
    {
        if (Find(item.Id) is FindResult<ILectures>.EntityDoesNotExist)
        {
            List.Add(item);
            return new AddResult<ILectures>.Success();
        }

        return new AddResult<ILectures>.EntityAlreadyExists();
    }

    public FindResult<ILectures> Find(Guid id)
    {
        ILectures? lectures = List.FirstOrDefault(lectures => lectures.Id == id);
        if (lectures == null)
        {
            return new FindResult<ILectures>.EntityDoesNotExist(lectures);
        }

        return new FindResult<ILectures>.Success(lectures);
    }

    public DeleteResult<ILectures> Delete(Guid id)
    {
        foreach (ILectures lectures in List)
        {
            if (lectures.Id == id)
            {
                List.RemoveAt(List.IndexOf(lectures));
                return new DeleteResult<ILectures>.Success();
            }
        }

        return new DeleteResult<ILectures>.EntityDoesNotExist();
    }
}