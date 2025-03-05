using Itmo.ObjectOrientedProgramming.Lab4.Outputs;
using Itmo.ObjectOrientedProgramming.Lab4.Services;
using Itmo.ObjectOrientedProgramming.Lab4.Visitors;

namespace Itmo.ObjectOrientedProgramming.Lab4;

public class LocalFileSystem : IFileSystem
{
    public string Address { get; private set; }

    public string Text { get; private set; }

    public IOutput ListDriver { get; private set; }

    public IOutput? ShowDriver { get; private set; }

    public LocalFileSystem(string address)
    {
        Address = address;
        ListDriver = new ConsoleOutput();
        Text = string.Empty;
    }

    public void Disconnect()
    {
        Address = string.Empty;
    }

    public void GoToDirectory(DirectoryEntity directoryEntity)
    {
        if (!Directory.Exists(directoryEntity.Path))
        {
            throw new ArgumentException("Directory does not exist");
        }

        Address = directoryEntity.Path;
    }

    public void Connect(string address)
    {
        if (!Directory.Exists(address))
        {
            throw new ArgumentException("Directory does not exist");
        }

        Address = address;
    }

    public void List(DirectoryEntity directory, int depth)
    {
        var visitor = new Visitor(ListDriver);
        directory.Accept(visitor);
    }

    public void Move(FileEntity file, DirectoryEntity directory)
    {
        File.Move(file.Path, directory.Path);
    }

    public void Rename(FileEntity file, string newName)
    {
        File.Move(file.Path, newName);
    }

    public void Show(FileEntity file, string mode)
    {
        if (mode == "console")
        {
            ShowDriver = new ConsoleOutput();
        }

        if (ShowDriver == null)
        {
            throw new ArgumentException("ShowDriver is not set");
        }

        Text = File.ReadAllText(file.Path);
        ShowDriver.Draw(Text);
        Text = string.Empty;
    }

    public void Copy(FileEntity file, DirectoryEntity directory)
    {
        File.Copy(file.Path, directory.Path);
    }

    public void Delete(FileEntity file)
    {
        File.Delete(file.Path);
    }

    public bool Equals(IFileSystem? other)
    {
        if (other is LocalFileSystem otherFileSystem)
        {
            return Equals(Address, otherFileSystem.Address);
        }

        return false;
    }

    public override int GetHashCode()
    {
        if (Address == null)
        {
            return string.Empty.GetHashCode(StringComparison.OrdinalIgnoreCase);
        }

        return Address.GetHashCode(StringComparison.OrdinalIgnoreCase);
    }

    public override bool Equals(object? obj)
    {
        if (obj is LocalFileSystem otherFileSystem)
        {
            return Equals(otherFileSystem);
        }

        return false;
    }
}