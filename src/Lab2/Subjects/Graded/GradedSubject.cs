using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Scores;
using Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Graded;

public class GradedSubject : ISubject, IGraded
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public IList<ILab> LabsList { get; }

    public IList<ILectures> LecturesList { get; private set; }

    public IUser Author { get; private set; }

    public Score Scores { get; private set; }

    public Guid? OriginSubjectId { get; private set; }

    public GradedSubject(
        string name,
        IList<ILab> labsList,
        IList<ILectures> lecturesList,
        IUser author,
        Score scores,
        Guid? originSubjectId)
    {
        Id = Guid.NewGuid();
        Name = name;
        LabsList = labsList;
        LecturesList = lecturesList;
        Author = author;
        Scores = scores;
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
        return new GradedSubject(Name, LabsList, LecturesList, Author, Scores, Id);
    }

    public ISubject CloneWithNewAuthor(IUser author)
    {
        return new GradedSubject(Name, LabsList, LecturesList, author, Scores, Id);
    }
}