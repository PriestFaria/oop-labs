using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Constants;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandHandlers;

public class ListCommandHandler : BaseCommandHandler
{
    private readonly CommandContext _context;

    public ListCommandHandler(CommandContext context)
    {
        _context = context;
    }

    public override ICommand Handle(string[] arguments)
    {
        if (arguments[1] != CommandConstants.ListCommandString)
        {
            if (NextHandler == null)
            {
                throw new InvalidOperationException(CommandConstants.NoHandlerExceptionInnerString);
            }

            return NextHandler.Handle(arguments);
        }

        if (arguments.Length == 4)
        {
            int depth = int.Parse(arguments[3]);

            var listCommand = new ListCommand(
                new DirectoryEntity(_context.GetCurrentFileSystem().Address),
                _context,
                depth);
            return listCommand;
        }

        if (arguments.Length == 2)
        {
            var listCommand = new ListCommand(
                new DirectoryEntity(_context.GetCurrentFileSystem().Address),
                _context);
            return listCommand;
        }

        throw new ArgumentException("Invalid arguments for list command");
    }
}