using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class AdresseeGroup : IAdressee
{
    private readonly ICollection<IAdressee> _userGroup;

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

        ReceiveResult result = new ReceiveResult.Success();

        foreach (IAdressee adresseeUser in _userGroup)
        {
            ReceiveResult receiveResult = adresseeUser.Receive(_message);
            if (receiveResult is not ReceiveResult.Success && result is not ReceiveResult.Success)
            {
                result = new ReceiveResult.Failed(receiveResult.Text);
            }
        }

        if (result is ReceiveResult.Failed)
        {
            return new SendMessageResult.Failed(result.Text);
        }

        return new SendMessageResult.Success();
    }

    public AdresseeGroup(ICollection<IAdressee> userGroup)
    {
        _message = null;
        _userGroup = userGroup;
    }
}