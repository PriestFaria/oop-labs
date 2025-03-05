using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Adressees;

public interface IAdressee
{
    ReceiveResult Receive(Message message);

    SendMessageResult Send();
}