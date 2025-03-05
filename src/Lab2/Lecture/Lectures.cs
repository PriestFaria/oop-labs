using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class Lectures : ILectures
{
    public Guid Id { get; private set; }

    public string Name { get; private set; }

    public string Description { get; private set; }

    public string Content { get; private set; }

    public IUser Author { get; private set; }

    public Guid? OriginLecturesId { get; private set; }

    public EditLecturesResult SetContent(IUser user, string newContent)
    {
        if (user.Id != Author.Id)
        {
            return new EditLecturesResult.UserHasNoPermission();
        }

        Content = newContent;
        return new EditLecturesResult.Success();
    }

    public EditLecturesResult SetDescription(IUser user, string newDescription)
    {
        if (user.Id != Author.Id)
        {
            return new EditLecturesResult.UserHasNoPermission();
        }

        Content = newDescription;
        return new EditLecturesResult.Success();
    }

    public EditLecturesResult SetName(IUser user, string newName)
    {
        if (user.Id != Author.Id)
        {
            return new EditLecturesResult.UserHasNoPermission();
        }

        Content = newName;
        return new EditLecturesResult.Success();
    }

    public Lectures(string name, string description, string content, IUser author, Guid? originLecturesId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Description = description;
        Content = content;
        Author = author;
        OriginLecturesId = originLecturesId;
    }

    public ILectures Clone()
    {
        return new Lectures(Name, Description, Content, Author, Id);
    }

    public ILectures CloneWithNewAuthor(IUser author)
    {
        return new Lectures(Name, Description, Content, author, Id);
    }
}