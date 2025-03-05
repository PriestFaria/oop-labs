using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public class EducationProgramRepository : IRepository<IEducationProgram>
{
    public IList<IEducationProgram> List { get; }

    public EducationProgramRepository()
    {
        List = new List<IEducationProgram>();
    }

    public AddResult<IEducationProgram> Add(IEducationProgram item)
    {
        if (Find(item.Id) is FindResult<IEducationProgram>.EntityDoesNotExist)
        {
            List.Add(item);
            return new AddResult<IEducationProgram>.Success();
        }

        return new AddResult<IEducationProgram>.EntityAlreadyExists();
    }

    public FindResult<IEducationProgram> Find(Guid id)
    {
        IEducationProgram? educationProgram = List.FirstOrDefault(educationProgram => educationProgram.Id == id);
        if (educationProgram == null)
        {
            return new FindResult<IEducationProgram>.EntityDoesNotExist(educationProgram);
        }

        return new FindResult<IEducationProgram>.Success(educationProgram);
    }

    public DeleteResult<IEducationProgram> Delete(Guid id)
    {
        foreach (IEducationProgram educationProgram in List)
        {
            if (educationProgram.Id == id)
            {
                List.RemoveAt(List.IndexOf(educationProgram));
                return new DeleteResult<IEducationProgram>.Success();
            }
        }

        return new DeleteResult<IEducationProgram>.EntityDoesNotExist();
    }
}