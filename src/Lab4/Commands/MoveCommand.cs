namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class MoveCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; }

    public FileEntity File { get; }

    public DirectoryEntity Directory { get; }

    public MoveCommand(FileEntity file, DirectoryEntity directory, CommandContext context)
    {
        File = file;
        Context = context;
        Directory = directory;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Move(File, Directory);
    }

    public bool Equals(ICommand? other)
    {
        if (other is MoveCommand otherCommand)
        {
            return Equals(File, otherCommand.File) && Equals(Directory, otherCommand.Directory);
        }

        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(File, Directory);
    }

    public override bool Equals(object? obj)
    {
        if (obj is MoveCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}