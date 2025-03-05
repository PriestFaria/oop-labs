using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;
using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab3.Users;

public class User : IUser
{
    public string Name { get; }

    public Collection<Message> ReadMessages { get; }

    public Collection<Message> UnreadMessages { get; }

    public ReceiveResult Receive(Message message)
    {
        UnreadMessages.Add(message);
        return new ReceiveResult.Success();
    }

    public User(string name)
    {
        Name = name;
        UnreadMessages = new Collection<Message>();
        ReadMessages = new Collection<Message>();
    }

    public ChangeMessageStatusResult ReadMessage(Message message)
    {
        foreach (Message userMessage in UnreadMessages)
        {
            if (message == userMessage)
            {
                ReadMessages.Add(userMessage);
                UnreadMessages.Remove(message);
                return new ChangeMessageStatusResult.Success();
            }
        }

        foreach (Message userMessage in ReadMessages)
        {
            if (message == userMessage)
            {
                return new ChangeMessageStatusResult.AlreadyRead();
            }
        }

        return new ChangeMessageStatusResult.MessageDoesNotExist();
    }
}