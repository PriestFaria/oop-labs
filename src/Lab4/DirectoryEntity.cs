using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class DirectoryEntity : IFileSystemEntity, IEquatable<IFileSystemEntity>
{
    public string Path { get; }

    public IReadOnlyCollection<IFileSystemEntity> GetComponents()
    {
        var components = new List<IFileSystemEntity>();

        foreach (string componentPath in Directory.EnumerateFileSystemEntries(Path))
        {
            components.Add(new FileEntity(componentPath));
        }

        foreach (string componentPath in Directory.EnumerateDirectories(Path))
        {
            components.Add(new FileEntity(componentPath));
        }

        return components;
    }

    public DirectoryEntity(string path)
    {
        Path = path;
    }

    public void Accept(IFileSystemComponentVisitor visitor)
    {
        visitor.Visit(this);
    }

    public override bool Equals(object? obj)
    {
        return obj is DirectoryEntity other && Equals(other);
    }

    public bool Equals(IFileSystemEntity? other)
    {
        return other is DirectoryEntity otherDirectory &&
               Path.Equals(otherDirectory.Path, StringComparison.OrdinalIgnoreCase);
    }

    public override int GetHashCode()
    {
        return Path.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }
}