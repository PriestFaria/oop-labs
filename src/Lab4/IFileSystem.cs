namespace Itmo.ObjectOrientedProgramming.Lab4.Services;

public interface IFileSystem
{
    string Address { get; }

    void Disconnect();

    void GoToDirectory(DirectoryEntity directoryEntity);

    void Connect(string address);

    void List(DirectoryEntity directory, int depth);

    void Move(FileEntity file, DirectoryEntity directory);

    void Rename(FileEntity file, string newName);

    void Show(FileEntity file, string mode);

    void Copy(FileEntity file, DirectoryEntity directory);

    void Delete(FileEntity file);
}