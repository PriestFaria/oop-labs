using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public interface IEducationProgram
{
    public IUser Lead { get;  }

    public Guid Id { get; }

    public string Name { get; }

    public IEducationPlan Program { get; }

    AddSubjectResult AddSubject(IUser user, uint semesterNumber, ISubject subject);
}