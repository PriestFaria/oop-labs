using Itmo.ObjectOrientedProgramming.Lab2.Labs;
using Itmo.ObjectOrientedProgramming.Lab2.Lecture;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Subjects.Interfaces;

public interface ISubjectBuilder
{
    ISubjectBuilder WithName(string name);

    ISubjectBuilder WithAuthor(IUser author);

    ISubjectBuilder WithLectures(ILectures lectures);

    ISubjectBuilder WithLab(ILab lab);

    ISubjectBuilder WithOriginSubjectId(Guid originSubjectId);

    ISubject Build();
}