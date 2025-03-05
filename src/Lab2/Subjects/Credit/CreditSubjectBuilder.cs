using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Credit;

public class CreditSubjectBuilder : ICreditSubjectBuilder
{
    public Credits MinCredits { get; private set; }

    private string? Name { get; set; }

    private IUser? Author { get; set; }

    private Guid? OriginSubjectId { get; set; }

    private IList<ILectures> LecturesList { get; set; }

    private IList<ILab> LabsList { get; set; }

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

    public ISubjectBuilder WithLecturesList(IList<ILectures> lecturesList)
    {
        LecturesList = lecturesList;
        return this;
    }

    public ISubjectBuilder WithLabsList(IList<ILab> labsList)
    {
        LabsList = labsList;
        return this;
    }

    public ISubjectBuilder WithOriginSubjectId(Guid originSubjectId)
    {
        OriginSubjectId = originSubjectId;
        return this;
    }

    ISubject ISubjectBuilder.Build()
    {
        return Build();
    }

    public ISubjectBuilder WithLab(ILab lab)
    {
        LabsList.Add(lab);
        return this;
    }

    public ISubjectBuilder WithLectures(ILectures lectures)
    {
        LecturesList.Add(lectures);
        return this;
    }

    public ICreditSubjectBuilder WithMinCredits(Credits minCredits)
    {
        MinCredits = minCredits;
        return this;
    }

    public ICredit Build()
    {
        if (LabsList.Sum(x => x.Scores) != 100)
        {
            throw new InvalidOperationException("Sum of scores for the subject is not equal to 100");
        }

        return new CreditSubject(
            LabsList,
            LecturesList,
            Name ?? throw new InvalidOperationException(),
            Author ?? throw new InvalidOperationException(),
            MinCredits,
            OriginSubjectId);
    }

    public CreditSubjectBuilder()
    {
        MinCredits = new Credits();
        OriginSubjectId = null;
        LabsList = new List<ILab>();
        LecturesList = new List<ILectures>();
    }
}