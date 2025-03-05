using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public class Topic : ITopic
{
    private readonly AdresseeGroup _adresseeGroup;
    private Message? _message;

    public string Name { get; private set; }

    public void Receive(Message message)
    {
        _message = message;
        _adresseeGroup.Receive(_message);
    }

    public SendMessageResult SendToGroup()
    {
        if (_message == null)
        {
            return new SendMessageResult.MessageDoesNotExist();
        }

        return _adresseeGroup.Send();
    }

    public Topic(string name, AdresseeGroup adresseeGroup)
    {
        _adresseeGroup = adresseeGroup;
        Name = name;
    }
}