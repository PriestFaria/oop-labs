namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class DisconnectCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; private set; }

    public DisconnectCommand(CommandContext context)
    {
        Context = context;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Disconnect();
    }

    public bool Equals(ICommand? other)
    {
        if (other is DisconnectCommand otherCommand)
        {
            return Equals(Context.GetCurrentFileSystem(), otherCommand.Context.GetCurrentFileSystem());
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Context.GetCurrentFileSystem());
    }

    public override bool Equals(object? obj)
    {
        if (obj is DisconnectCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}