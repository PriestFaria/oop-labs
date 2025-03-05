using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.EducationPrograms;

public class EducationPlan : IEducationPlan
{
    public IDictionary<uint, IList<ISubject>> Plan { get; private set; }

    public EducationPlan()
    {
        Plan = new Dictionary<uint, IList<ISubject>>();
    }
}