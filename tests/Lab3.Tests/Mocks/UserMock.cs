using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Lab3.Tests.Mocks;

public class UserMock : IUser
{
    public string Name { get; }

    public Message? Message { get; private set; }

    public ReceiveResult Receive(Message message)
    {
        Message = message;
        return new ReceiveResult.Success();
    }

    public UserMock(string name)
    {
        Name = name;
    }
}