using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public class EducationProgram : IEducationProgram
{
    public IUser Lead { get; }

    public Guid Id { get; }

    public string Name { get; }

    public IEducationPlan Program { get; private set; }

    public EducationProgram(IUser lead, string name)
    {
        Id = Guid.NewGuid();
        Name = name;
        Lead = lead;
        Program = new EducationPlan();
    }

    public AddSubjectResult AddSubject(IUser user, uint semesterNumber, ISubject subject)
    {
        if (user.Id != Lead.Id)
        {
            return new AddSubjectResult.UserHasNoPermission();
        }

        foreach (ISubject semesterSubject in Program.Plan[semesterNumber])
        {
            if (semesterSubject.Id == subject.Id)
            {
                return new AddSubjectResult.AlreadyExisting();
            }
        }

        Program.Plan[semesterNumber].Add(subject);
        return new AddSubjectResult.Success();
    }
}