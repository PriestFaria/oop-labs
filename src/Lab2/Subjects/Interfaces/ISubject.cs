using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

public interface ISubject : IPrototype<ISubject>
{
    public Guid Id { get; }

    public IList<ILab> LabsList { get; }

    public IList<ILectures> LecturesList { get; }

    public string Name { get; }

    public IUser Author { get;  }

    public Guid? OriginSubjectId { get; }

    EditSubjectResult SetName(IUser user, string newName);

    EditSubjectResult AddLectures(IUser user, ILectures lectures);

    EditSubjectResult RemoveLectures(IUser user, ILectures lectures);
}