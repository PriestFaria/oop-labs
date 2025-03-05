using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Displays;

public class Display : IDisplay
{
    private Message? _message;

    public IDisplayDriver Driver { get; private set; }

    public ReceiveResult Receive(Message message)
    {
        _message = message;
        return new ReceiveResult.Success();
    }

    public void Print()
    {
        Driver.Print(Format());
    }

    public string Format()
    {
        if (_message == null)
        {
            return string.Empty;
        }

        return $"{_message.Name} {_message.Body}";
    }

    public Display(IDisplayDriver driver)
    {
        _message = null;
        Driver = driver;
    }
}