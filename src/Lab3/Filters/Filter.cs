using Itmo.ObjectOrientedProgramming.Lab3.Adressees;
using Itmo.ObjectOrientedProgramming.Lab3.Messages;
using Itmo.ObjectOrientedProgramming.Lab3.Priorities;
using Itmo.ObjectOrientedProgramming.Lab3.ResultTypes;

namespace Itmo.ObjectOrientedProgramming.Lab3.Filters;

public class Filter : IAdressee
{
    public IAdressee Adressee { get; }

    private readonly ICollection<Priority> _priorities = new List<Priority>();

    public Filter(IAdressee adressee, ICollection<Priority> priorities)
    {
        _priorities = priorities;
        Adressee = adressee;
    }

    public ReceiveResult Receive(Message message)
    {
        if (_priorities.Contains(message.Priority))
        {
            return Adressee.Receive(message);
        }

        return new ReceiveResult.RejectedByFilter();
    }

    public SendMessageResult Send()
    {
        return Adressee.Send();
    }
}