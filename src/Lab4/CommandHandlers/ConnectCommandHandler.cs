using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ConnectCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public ConnectCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[0] != CommandConstants.ConnectCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException();
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 4)
        {
            throw new ArgumentException(CommandConstants.NoHandlerExceptionInnerString);
        }

        string directory = arguments[1];
        string mode = arguments[3];

        var connectCommand = new ConnectCommand(directory, mode, _context);
        return connectCommand;
    }
}