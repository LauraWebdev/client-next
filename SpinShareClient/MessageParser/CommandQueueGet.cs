using PhotinoNET;

namespace SpinShareClient.MessageParser;

using DownloadQueue;

/// <summary>
/// A command that returns the <see cref="DownloadQueue.Queue"/>
/// </summary>
public class CommandQueueGet : ICommand
{
    private DownloadQueue? _downloadQueue;
    
    public async Task Execute(PhotinoWindow? sender, object? data)
    {
        _downloadQueue = DownloadQueue.GetInstance();

        Message response = new() {
            Command = "queue-get-response",
            Data = _downloadQueue.GetQueue()
        };

        await Task.Yield();
        
        MessageHandler.SendResponse(sender, response);
    }
}