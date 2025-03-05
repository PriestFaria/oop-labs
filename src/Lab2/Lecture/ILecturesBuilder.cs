using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public interface ILecturesBuilder
{
    public ILecturesBuilder WithName(string name);

    public ILecturesBuilder WithDescription(string description);

    public ILecturesBuilder WithAuthor(IUser author);

    public ILecturesBuilder WithContent(string content);

    public ILectures Build();
}