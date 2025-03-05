using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class LabRepository : IRepository<ILab>
{
    public IList<ILab> List { get; }

    public LabRepository()
    {
        List = new List<ILab>();
    }

    public AddResult<ILab> Add(ILab item)
    {
        if (Find(item.Id) is FindResult<ILab>.EntityDoesNotExist)
        {
            List.Add(item);
            return new AddResult<ILab>.Success();
        }

        return new AddResult<ILab>.EntityAlreadyExists();
    }

    public FindResult<ILab> Find(Guid id)
    {
        ILab? lab = List.FirstOrDefault(lab => lab.Id == id);
        if (lab == null)
        {
            return new FindResult<ILab>.EntityDoesNotExist(lab);
        }

        return new FindResult<ILab>.Success(lab);
    }

    public DeleteResult<ILab> Delete(Guid id)
    {
        foreach (ILab lab in List)
        {
            if (lab.Id == id)
            {
                List.RemoveAt(List.IndexOf(lab));
                return new DeleteResult<ILab>.Success();
            }
        }

        return new DeleteResult<ILab>.EntityDoesNotExist();
    }
}