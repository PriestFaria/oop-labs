namespace Itmo.ObjectOrientedProgramming.Lab4.Commands;

public class CopyCommand : ICommand, IEquatable<ICommand>
{
    public CommandContext Context { get; private set; }

    public FileEntity File { get; private set; }

    public DirectoryEntity Directory { get; private set; }

    public CopyCommand(FileEntity file, DirectoryEntity directory, CommandContext context)
    {
        File = file;
        Directory = directory;
        Context = context;
    }

    public void Execute()
    {
        Context.GetCurrentFileSystem().Copy(File, Directory);
    }

    public bool Equals(ICommand? other)
    {
        if (other is CopyCommand otherCommand)
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
        if (obj is CopyCommand otherCommand)
        {
            return Equals(otherCommand);
        }

        return false;
    }
}