using Itmo.ObjectOrientedProgramming.Lab2.Prototypes;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Labs;

public interface ILab : IPrototype<ILab>
{
    public Guid Id { get; }

    public string Name { get; }

    public string Description { get; }

    public int Scores { get;  }

    public IUser Author { get; }

    public string Criterias { get; }

    public Guid? OriginLabId { get; }

    EditLabResult SetName(IUser user, string newName);

    EditLabResult SetCriterias(IUser user, string newCriterias);

    EditLabResult SetDescription(IUser user, string newDescription);
}