using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Messengers;

public class Messenger : IMessenger
{
    private Message? _message;

    public ShowResult Show()
    {
        if (_message == null)
        {
            return new ShowResult.MessageDoesNotExist();
        }

        Console.Out.WriteLine("Мессенджер: " + _message.Body);
        return new ShowResult.Success();
    }

    public ReceiveResult Receive(Message message)
    {
        _message = message;
        return new ReceiveResult.Success();
    }

    public Messenger()
    {
        _message = null;
    }
}