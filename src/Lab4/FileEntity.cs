using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class FileEntity : IFileSystemEntity, IEquatable<IFileSystemEntity>
{
    public string Path { get; }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public FileEntity(string path)
    {
        Path = path;
    }

    public override bool Equals(object? obj)
    {
        return obj is FileEntity other && Equals(other);
    }

    public bool Equals(IFileSystemEntity? other)
    {
        return other is FileEntity otherDirectory &&
               Path.Equals(otherDirectory.Path, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Path.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}