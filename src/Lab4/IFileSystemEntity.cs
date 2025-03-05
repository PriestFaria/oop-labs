using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public interface IFileSystemEntity
{
    string Path { get; }

    void Accept(IFileSystemComponentVisitor visitor);
}