namespace Itmo.ObjectOrientedProgramming.Lab4.Visitors;

public interface IFileSystemComponentVisitor
{
    void Visit(FileEntity component);

    void Visit(DirectoryEntity component);
}