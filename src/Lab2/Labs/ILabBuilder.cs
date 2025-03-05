using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public interface ILabBuilder
{
    public ILabBuilder WithName(string name);

    public ILabBuilder WithDescription(string description);

    public ILabBuilder WithAuthor(IUser author);

    public ILabBuilder WithScores(int scores);

    public ILabBuilder WithCriterias(string criterias);

    public ILab Build();
}