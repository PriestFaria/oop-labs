using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public interface IEducationPlan
{
    public IDictionary<uint, IList<ISubject>> Plan { get; }
}