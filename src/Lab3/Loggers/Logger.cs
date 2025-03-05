using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Loggers;

public class Logger : IAdressee
{
    public IAdressee Adressee { get; }

    private Message? _message;

    public Logger(IAdressee adressee)
    {
        Adressee = adressee;
    }

    public ReceiveResult Receive(Message message)
    {
        _message = message;
        ReceiveResult result = Adressee.Receive(message);

        Log(
            $"Received:\n\tBody:{_message.Body}\nName:{_message.Name}\nPriority:{_message.Priority.ToString()}\n\tWith result: {result.Text}");
        return result;
    }

    public SendMessageResult Send()
    {
        SendMessageResult result = Adressee.Send();

        if (_message == null)
        {
            Log("Tried to send a null message");
            return result;
        }

        Log($"Sent:\n\tBody:{_message.Body}\nName:{_message.Name}\nPriority:{_message.Priority.ToString()}\\n\\tWith result: {result.Text}");
        return result;
    }

    public void Log(string log)
    {
        Console.Out.WriteLine(log);
    }
}