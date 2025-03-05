using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class AdreseeMessenger : IAdressee
{
    private readonly IMessenger _messenger;

    private readonly Message? _message;

    public ReceiveResult Receive(Message message)
    {
        return new ReceiveResult.NullMessageReceived();
    }

    public SendMessageResult Send()
    {
        if (_message == null)
        {
            return new SendMessageResult.MessageDoesNotExist();
        }

        _messenger.Receive(_message);
        return new SendMessageResult.Success();
    }

    public AdreseeMessenger(IMessenger messenger)
    {
        _message = null;
        _messenger = messenger;
    }
}