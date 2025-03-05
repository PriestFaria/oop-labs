using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public class Lab : ILab
{
    public Guid Id { get; private set; }

    public int Scores { get; private set; }

    public string Name { get; private set; }

    public string Criterias { get; private set; }

    public IUser Author { get; private set; }

    public string Description { get; private set; }

    public Guid? OriginLabId { get; private set; }

    public Lab(
        string name,
        string criterias,
        int scores,
        IUser author,
        string description,
        Guid? originLabId)
    {
        Id = Guid.NewGuid();
        Name = name;
        Criterias = criterias;
        Scores = scores;
        OriginLabId = originLabId;
        Author = author;
        Description = description;
    }

    public EditLabResult SetName(IUser user, string newName)
    {
        if (user.Id != Author.Id)
        {
            return new EditLabResult.UserHasNoPermission();
        }

        Name = newName;
        return new EditLabResult.Success();
    }

    public EditLabResult SetCriterias(IUser user, string newCriterias)
    {
        if (user.Id != Author.Id)
        {
            return new EditLabResult.UserHasNoPermission();
        }

        Criterias = newCriterias;
        return new EditLabResult.Success();
    }

    public EditLabResult SetDescription(IUser user, string newDescription)
    {
        if (user.Id != Author.Id)
        {
            return new EditLabResult.UserHasNoPermission();
        }

        Description = newDescription;
        return new EditLabResult.Success();
    }

    public ILab Clone()
    {
        return new Lab(Name, Criterias, Scores, Author, Description, Id);
    }

    public ILab CloneWithNewAuthor(IUser author)
    {
        return new Lab(Name, Criterias, Scores, author, Description, Id);
    }
}