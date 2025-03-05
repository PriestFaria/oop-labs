using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Topics;

public interface ITopic
{
    void Receive(Message message);

    SendMessageResult SendToGroup();
}