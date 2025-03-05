using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class DeleteCommandHandler : BaseCommandHandler
{
    private const string DeleteCommandString = "delete";

    private readonly CommandContext _context;

    public DeleteCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != DeleteCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length != 3)
        {
            throw new ArgumentException("Invalid arguments for delete command");
        }

        string path = arguments[2];
        var deleteCommand = new DeleteCommand(new FileEntity(path), _context);
        return deleteCommand;
    }
}