using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Credit;

public interface ICreditSubjectBuilder : ISubjectBuilder
{
    ICreditSubjectBuilder WithMinCredits(Credits minCredits);
}