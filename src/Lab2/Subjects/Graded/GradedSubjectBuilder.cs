using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Graded;

public class GradedSubjectBuilder : IGradedSubjectBuilder
{
    public Guid? Id { get; set; }

    public IList<ILab> LabsList { get; }

    public IList<ILectures> LecturesList { get; private set; }

    public string? Name { get; private set; }

    public IUser? Author { get; private set; }

    public Score Scores { get; private set; }

    public Guid? OriginSubjectId { get; private set; }

    public ISubjectBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public ISubjectBuilder WithAuthor(IUser author)
    {
        Author = author;
        return this;
    }

    public ISubjectBuilder WithLectures(ILectures lectures)
    {
        LecturesList.Add(lectures);
        return this;
    }

    public ISubjectBuilder WithLab(ILab lab)
    {
        LabsList.Add(lab);
        return this;
    }

    public ISubjectBuilder WithOriginSubjectId(Guid originSubjectId)
    {
        OriginSubjectId = originSubjectId;
        return this;
    }

    public IGradedSubjectBuilder WithScores(Score scores)
    {
        Scores = scores;
        return this;
    }

    public GradedSubjectBuilder()
    {
        Scores = new Score();
        OriginSubjectId = null;
        LabsList = new List<ILab>();
        LecturesList = new List<ILectures>();
    }

    public ISubject Build()
    {
        if (Scores.Value + LabsList.Sum(x => x.Scores) != 100)
        {
            throw new InvalidOperationException("Sum of scores for the subject is not equal to 100");
        }

        return new GradedSubject(
            Name ?? throw new InvalidOperationException(),
            LabsList,
            LecturesList,
            Author ?? throw new InvalidOperationException(),
            Scores,
            OriginSubjectId);
    }
}