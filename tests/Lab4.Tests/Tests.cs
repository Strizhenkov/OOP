using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Parsers;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab4.Tests;

public class Tests
{
    [Fact]
    public void ParserConnectTest()
    {
        string input = "connect C:\\Test local";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (ConnectCommand)result;
        Assert.Equal(typeof(ConnectCommand), command.GetType());
        Assert.Equal("C:\\Test", command.HomePath);
        Assert.Equal("local", command.Mode);
    }

    [Fact]
    public void ParserDisconnectTest()
    {
        string input = "disconnect";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (DisconnectCommand)result;
        Assert.Equal(typeof(DisconnectCommand), command.GetType());
    }

    [Fact]
    public void ParserTreeGotoTest()
    {
        string input = "tree goto C:\\Test\\NewFolder";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (GotoCommand)result;
        Assert.Equal(typeof(GotoCommand), command.GetType());
        Assert.Equal("C:\\Test\\NewFolder", command.Path);
    }

    [Fact]
    public void ParserTreeListTest()
    {
        string input = "tree list 1";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (ListCommand)result;
        Assert.Equal(typeof(ListCommand), command.GetType());
        Assert.Equal(1, command.Depth);
    }

    [Fact]
    public void ParserFileShowTest()
    {
        string input = "file show myfile.txt console";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (ShowCommand)result;
        Assert.Equal(typeof(ShowCommand), command.GetType());
        Assert.Equal("myfile.txt", command.Path);
    }

    [Fact]
    public void ParserFileMoveTest()
    {
        string input = "file move C:\\Test\\myfile.txt C:\\Test\\NewFolder";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (MoveCommand)result;
        Assert.Equal(typeof(MoveCommand), command.GetType());
        Assert.Equal("C:\\Test\\myfile.txt", command.SourcePath);
        Assert.Equal("C:\\Test\\NewFolder", command.DestinationPath);
    }

    [Fact]
    public void ParserFileCopyTest()
    {
        string input = "file copy C:\\Test\\myfile.txt C:\\Test\\NewFolder";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (CopyCommand)result;
        Assert.Equal(typeof(CopyCommand), command.GetType());
        Assert.Equal("C:\\Test\\myfile.txt", command.SourcePath);
        Assert.Equal("C:\\Test\\NewFolder", command.DestinationPath);
    }

    [Fact]
    public void ParserFileDeleteTest()
    {
        string input = "file delete C:\\Test\\myfile.txt";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (DeleteCommand)result;
        Assert.Equal(typeof(DeleteCommand), command.GetType());
        Assert.Equal("C:\\Test\\myfile.txt", command.Path);
    }

    [Fact]
    public void ParserFileRenameTest()
    {
        string input = "file rename C:\\Test\\myfile.txt test.txt";
        var parser = new TypeCommandParser();
        ICommand result = parser.Execute(input);
        var command = (RenameCommand)result;
        Assert.Equal(typeof(RenameCommand), command.GetType());
        Assert.Equal("C:\\Test\\myfile.txt", command.Path);
        Assert.Equal("test.txt", command.NewName);
    }
}