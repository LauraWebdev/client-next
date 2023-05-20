using System;

namespace SpinShareClient.MessageParser;

public class CommandFactory
{
    public ICommand GetCommand(string command)
    {
        switch(command)
        {
            case "open-in-browser":
                return new CommandOpenInBrowser();
            case "open-in-explorer":
                return new CommandOpenInExplorer();
            case "library-select-path":
                return new CommandLibrarySelectPath();
            case "library-get-path":
                return new CommandLibraryGetPath();
            case "library-open-in-explorer":
                return new CommandLibraryOpenInExplorer();
            case "library-build-cache":
                return new CommandLibraryBuildCache();
            case "library-get":
                return new CommandLibraryGet();
            case "library-get-state":
                return new CommandLibraryGetState();
            case "queue-add":
                return new CommandAddToQueue();
            case "queue-get-count":
                return new CommandGetQueueCount();
            case "settings-set":
                return new CommandSettingsSet();
            default:
                throw new Exception($"Unknown command: {command}");
        }
    }
}