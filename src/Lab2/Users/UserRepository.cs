using Itmo.ObjectOrientedProgramming.Lab2.Repositories;
using Itmo.ObjectOrientedProgramming.Lab2.ResultTypes.RepositoryResults;

namespace Itmo.ObjectOrientedProgramming.Lab2.Users;

public class UserRepository : IRepository<IUser>
{
    public IList<IUser> List { get; }

    public UserRepository()
    {
        List = new List<IUser>();
    }

    public AddResult<IUser> Add(IUser item)
    {
        if (Find(item.Id) is FindResult<IUser>.EntityDoesNotExist)
        {
            List.Add(item);
            return new AddResult<IUser>.Success();
        }

        return new AddResult<IUser>.EntityAlreadyExists();
    }

    public FindResult<IUser> Find(Guid id)
    {
        IUser? user = List.FirstOrDefault(user => user.Id == id);
        if (user == null)
        {
            return new FindResult<IUser>.EntityDoesNotExist(user);
        }

        return new FindResult<IUser>.Success(user);
    }

    public DeleteResult<IUser> Delete(Guid id)
    {
        foreach (IUser user in List)
        {
            if (user.Id == id)
            {
                List.RemoveAt(List.IndexOf(user));
                return new DeleteResult<IUser>.Success();
            }
        }

        return new DeleteResult<IUser>.EntityDoesNotExist();
    }
}