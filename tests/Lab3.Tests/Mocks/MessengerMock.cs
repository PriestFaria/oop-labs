using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Messengers;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Lab3.Tests.Mocks;

public class MessengerMock : IMessenger
{
    private Message? _message;

    public string? MessageShowed { get; private set; }

    public ShowResult Show()
    {
        if (_message == null)
        {
            return new ShowResult.MessageDoesNotExist();
        }

        MessageShowed = "Мессенджер: " + _message.Body;
        return new ShowResult.Success();
    }

    public ReceiveResult Receive(Message message)
    {
        _message = message;
        return new ReceiveResult.Success();
    }

    public MessengerMock()
    {
        _message = null;
        MessageShowed = null;
    }
}