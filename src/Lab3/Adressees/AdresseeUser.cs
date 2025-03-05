using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using Itmo.ObjectOrientedProgramming.Lab3.Users;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class AdresseeUser : IAdressee
{
    private readonly IUser _user;

    private Message? _message;

    public ReceiveResult Receive(Message message)
    {
        _message = message;
        return new ReceiveResult.Success();
    }

    public SendMessageResult Send()
    {
        if (_message == null)
        {
            return new SendMessageResult.MessageDoesNotExist();
        }

        ReceiveResult result = _user.Receive(_message);
        if (result is not ReceiveResult.Success)
        {
            return new SendMessageResult.Failed(result.Text);
        }

        return new SendMessageResult.Success();
    }

    public AdresseeUser(IUser user)
    {
        _message = null;
        _user = user;
    }
}