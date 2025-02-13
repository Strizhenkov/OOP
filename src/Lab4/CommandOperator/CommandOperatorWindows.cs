using Itmo.ObjectOrientedProgramming.Lab4.Commands;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Connect;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Disconnect;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Copy;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Delete;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Move;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Rename;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.FIle.Show;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.Gotoo;
using Itmo.ObjectOrientedProgramming.Lab4.Commands.Strategies.Tree.List;

namespace Itmo.ObjectOrientedProgramming.Lab4.CommandOperator;

public class CommandOperatorWindows : ICommandOperator
{
    public string HomePath { get; private set; } = string.Empty;
    public string CommandRun(ICommand command)
    {
        MakeAllPathAbsolute(command);
        switch (command)
        {
            case ConnectCommand updatedCommand:
                updatedCommand.Strategy = new WindowsConnect();
                if (updatedCommand.Execute(HomePath) != "Connect" || updatedCommand.HomePath == null)
                    return "Wrong Connect";
                HomePath = updatedCommand.HomePath;
                return "Connect";
            case DisconnectCommand updatedCommand:
                updatedCommand.Strategy = new WindowsDisconnect();
                if (updatedCommand.Execute(HomePath) == "Disconnect")
                    HomePath = string.Empty;
                return "Disconnect";
            case ListCommand updatedCommand:
                updatedCommand.Strategy = new WindowsList();
                return updatedCommand.Execute(HomePath);
            case GotoCommand updatedCommand:
                updatedCommand.Strategy = new WindowsGoto();
                if (updatedCommand.Execute(HomePath) == "Directory changed" && updatedCommand.Path != null)
                    HomePath = updatedCommand.Path;
                return "Directory changed";
            case CopyCommand updatedCommand:
                updatedCommand.Strategy = new WindowsCopy();
                return updatedCommand.Execute(HomePath) == "File coped successfully" ? "File coped successfully" : "Wrong Path";
            case DeleteCommand updatedCommand:
                updatedCommand.Strategy = new WindowsDelete();
                return updatedCommand.Execute(HomePath) == "File deleted successfully" ? "Delete deleted successfully" : "Wrong path";
            case MoveCommand updatedCommand:
                updatedCommand.Strategy = new WindowsMove();
                return updatedCommand.Execute(HomePath) == "File moved successfully" ? "File moved successfully" : "Wrong Path";
            case RenameCommand updatedCommand:
                updatedCommand.Strategy = new WindowsRename();
                return updatedCommand.Execute(HomePath) == "File renamed successfully" ? "File renamed successfully" : "Wrong Path";
            case ShowCommand updatedCommand:
                updatedCommand.Strategy = new WindowsShow();
                string result = updatedCommand.Execute(HomePath);
                return result != "Wrong Path" && result != "Wrong Flag" ? result : "Wrong Path or Flag";
            default:
                return "Wrong Command";
        }
    }

    private void MakeAllPathAbsolute(ICommand command)
    {
        #pragma warning disable CA1307
        switch (command)
        {
            case GotoCommand gotoCommand:
                if (gotoCommand.Path?.IndexOf(':') != 2)
                    gotoCommand.Path = HomePath + "\\" + gotoCommand.Path;
                break;
            case CopyCommand gotoCommand:
                if (gotoCommand.DestinationPath?.IndexOf(':') != 2)
                    gotoCommand.DestinationPath = HomePath + "\\" + gotoCommand.DestinationPath;
                if (gotoCommand.SourcePath?.IndexOf(':') != 2)
                    gotoCommand.SourcePath = HomePath + "\\" + gotoCommand.SourcePath;
                break;
            case DeleteCommand gotoCommand:
                if (gotoCommand.Path?.IndexOf(':') != 2)
                    gotoCommand.Path = HomePath + "\\" + gotoCommand.Path;
                break;
            case MoveCommand gotoCommand:
                if (gotoCommand.DestinationPath?.IndexOf(':') != 2)
                    gotoCommand.DestinationPath = HomePath + "\\" + gotoCommand.DestinationPath;
                if (gotoCommand.SourcePath?.IndexOf(':') != 2)
                    gotoCommand.SourcePath = HomePath + "\\" + gotoCommand.SourcePath;
                break;
            case RenameCommand gotoCommand:
                if (gotoCommand.Path?.IndexOf(':') != 2)
                    gotoCommand.Path = HomePath + "\\" + gotoCommand.Path;
                break;
            case ShowCommand gotoCommand:
                if (gotoCommand.Path?.IndexOf(':') != 2)
                    gotoCommand.Path = HomePath + "\\" + gotoCommand.Path;
                break;
        }
        #pragma warning restore CA1307
    }
}