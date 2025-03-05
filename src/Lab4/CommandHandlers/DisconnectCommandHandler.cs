using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DisconnectCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public DisconnectCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[0] != CommandConstants.DisconnectCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 1)
        {
            throw new ArgumentException("Invalid arguments for disconnect command");
        }

        var disconnectCommand = new DisconnectCommand(_context);
        return disconnectCommand;
    }
}