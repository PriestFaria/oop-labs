using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Graded;

public interface IGradedSubjectBuilder : ISubjectBuilder
{
    IGradedSubjectBuilder WithScores(Score scores);
}