using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Credit;

public class CreditSubject : ISubject, ICredit
{
    public Guid Id { get; private set; }

    public IList<ILab> LabsList { get; }

    public IList<ILectures> LecturesList { get; private set; }

    public string Name { get; private set; }

    public IUser Author { get; private set; }

    public Credits MinCredits { get; private set; }

    public Guid? OriginSubjectId { get; private set; }

    public CreditSubject(
        IList<ILab> labsList,
        IList<ILectures> lecturesList,
        string name,
        IUser author,
        Credits minCredits,
        Guid? originSubjectId)
    {
        Id = Guid.NewGuid();
        LabsList = labsList;
        LecturesList = lecturesList;
        Name = name;
        Author = author;
        MinCredits = minCredits;
        OriginSubjectId = originSubjectId;
    }

    public EditSubjectResult SetName(IUser user, string newName)
    {
        if (user.Id != Author.Id)
        {
            return new EditSubjectResult.UserHasNoPermission();
        }

        Name = newName;
        return new EditSubjectResult.Success();
    }

    public EditSubjectResult AddLectures(IUser user, ILectures lectures)
    {
        if (user.Id != Author.Id)
        {
            return new EditSubjectResult.UserHasNoPermission();
        }

        if (LecturesList.Contains(lectures))
        {
            return new EditSubjectResult.AlreadyExisting();
        }

        LecturesList.Add(lectures);
        return new EditSubjectResult.Success();
    }

    public EditSubjectResult RemoveLectures(IUser user, ILectures lectures)
    {
        if (user.Id != Author.Id)
        {
            return new EditSubjectResult.UserHasNoPermission();
        }

        if (!LecturesList.Contains(lectures))
        {
            return new EditSubjectResult.ElementNotExisting();
        }

        LecturesList.Remove(lectures);

        return new EditSubjectResult.Success();
    }

    public ISubject Clone()
    {
        return new CreditSubject(LabsList, LecturesList, Name, Author, MinCredits, Id);
    }

    public ISubject CloneWithNewAuthor(IUser author)
    {
        return new CreditSubject(LabsList, LecturesList, Name, author, MinCredits, Id);
    }
}