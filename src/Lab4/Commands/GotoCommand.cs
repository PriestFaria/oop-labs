namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class GotoCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; }

    public DirectoryEntity Directory { get; }

    public GotoCommand(DirectoryEntity directory, CommandContext context)
    {
        Directory = directory;
        Context = context;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().GoToDirectory(Directory);
    }

    public bool Equals(ICommand? other)
    {
        if (other is GotoCommand otherCommand)
        {
            return Equals(Directory, otherCommand.Directory) &&
                   Equals(Context.GetCurrentFileSystem(), otherCommand.Context.GetCurrentFileSystem());
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Directory, Context.GetCurrentFileSystem());
    }

    public override bool Equals(object? obj)
    {
        if (obj is GotoCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}