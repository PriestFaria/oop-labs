namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class User : IUser
{
    public Guid Id { get; }

    public string Name { get; private set; }

    public User(string name)
    {
        Name = name;
        Id = Guid.NewGuid();
    }
}