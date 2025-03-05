namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class ListCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; }

    public int Depth { get; }

    public DirectoryEntity Directory { get; }

    public ListCommand(DirectoryEntity directory, CommandContext context, int depth = 1)
    {
        Depth = depth;
        Context = context;
        Directory = directory;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().List(Directory, Depth);
    }

    public bool Equals(ICommand? other)
    {
        if (other is ListCommand otherCommand)
        {
            return Equals(Depth, otherCommand.Depth) && Equals(Directory, otherCommand.Directory);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Directory, Depth);
    }

    public override bool Equals(object? obj)
    {
        if (obj is ListCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}