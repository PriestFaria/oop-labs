using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public interface ILectures : IPrototype<ILectures>
{
    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public string Content { get; }

    public IUser Author { get; }

    public Guid? OriginLecturesId { get;  }

    EditLecturesResult SetContent(IUser user, string newContent);

    EditLecturesResult SetDescription(IUser user, string newDescription);

    EditLecturesResult SetName(IUser user, string newName);
}