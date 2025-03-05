using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class MoveCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public MoveCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.MoveCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 4)
        {
            throw new ArgumentException("Invalid arguments for move command");
        }

        string sourcePath = arguments[2];
        string destinationPath = arguments[3];

        var moveCommand = new MoveCommand(new FileEntity(sourcePath), new DirectoryEntity(destinationPath), _context);
        return moveCommand;
    }
}