using Itmo.ObjectOrientedProgramming.Lab3.Displays;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public class AdresseeDisplay : IAdressee
{
    public IDisplay Display { get; private set; }

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

        Display.Receive(_message);
        Display.Print();
        return new SendMessageResult.Success();
    }

    public AdresseeDisplay(IDisplay display)
    {
        Display = display;
        _message = null;
    }
}