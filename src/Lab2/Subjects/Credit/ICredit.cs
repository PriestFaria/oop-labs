using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Credit;

public interface ICredit : ISubject
{
    public Credits MinCredits { get; }
}