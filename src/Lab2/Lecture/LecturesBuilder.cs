using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Lecture;

public class LecturesBuilder : ILecturesBuilder
{
    private string? Name { get; set; }

    private string? Description { get; set; }

    private string? Content { get; set; }

    private IUser? Author { get; set; }

    private Guid? OriginLecturesId { get; set; }

    public LecturesBuilder()
    {
        OriginLecturesId = null;
    }

    public ILecturesBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public ILecturesBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }

    public ILecturesBuilder WithContent(string content)
    {
        Content = content;
        return this;
    }

    public ILecturesBuilder WithAuthor(IUser author)
    {
        Author = author;
        return this;
    }

    public ILectures Build()
    {
        return new Lectures(
            Name ?? throw new InvalidOperationException(),
            Description ?? throw new InvalidOperationException(),
            Content ?? throw new InvalidOperationException(),
            Author ?? throw new InvalidOperationException(),
            OriginLecturesId);
    }
}