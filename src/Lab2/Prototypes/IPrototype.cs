using Itmo.ObjectOrientedProgramming.Lab2.Users;

namespace Itmo.ObjectOrientedProgramming.Lab2.Prototypes;

public interface IPrototype<out T>
{
    T Clone();

    T CloneWithNewAuthor(IUser author);
}