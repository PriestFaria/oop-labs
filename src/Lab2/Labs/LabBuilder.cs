using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class LabBuilder : ILabBuilder
{
    public Guid? Id { get; private set; }

    public int? Scores { get; private set; }

    public string? Name { get; private set; }

    public string? Criterias { get; private set; }

    public string? Description { get; private set; }

    public Guid? OriginLabId { get; private set; }

    public IUser? Author { get; private set; }

    public LabBuilder()
    {
        OriginLabId = null;
    }

    public ILabBuilder WithId(Guid id)
    {
        Id = id;
        return this;
    }

    public ILabBuilder WithDescription(string description)
    {
        Description = description;
        return this;
    }

    public ILabBuilder WithScores(int scores)
    {
        Scores = scores;
        return this;
    }

    public ILabBuilder WithName(string name)
    {
        Name = name;
        return this;
    }

    public ILabBuilder WithCriterias(string criterias)
    {
        Criterias = criterias;
        return this;
    }

    public ILabBuilder WithOriginLabId(Guid originLabId)
    {
        OriginLabId = originLabId;
        return this;
    }

    public ILabBuilder WithAuthor(IUser author)
    {
        Author = author;
        return this;
    }

    public ILab Build()
    {
        return new Lab(
            Name ?? throw new InvalidOperationException(),
            Criterias ?? throw new InvalidOperationException(),
            Scores ?? throw new InvalidOperationException(),
            Author ?? throw new InvalidOperationException(),
            Description ?? throw new InvalidOperationException(),
            OriginLabId);
    }
}