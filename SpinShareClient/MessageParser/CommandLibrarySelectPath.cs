using PhotinoNET;

namespace SpinShareClient.MessageParser;

public class CommandLibrarySelectPath : ICommand
{
    private SettingsManager? _settingsManager;
    
    public async Task Execute(PhotinoWindow? sender, object? data)
    {
        _settingsManager = SettingsManager.GetInstance();
        
        string defaultLibraryPath = _settingsManager.Get<string>("library.path") ?? SettingsManager.GetLibraryPath() ?? "";
        string[]? resultPath = sender?.ShowOpenFolder(
            "Spin Rhythm XD library location",
            Directory.Exists(defaultLibraryPath) ? defaultLibraryPath : null, 
            false
        );
        
        await Task.Yield();

        if (resultPath?.Length == 1 && Directory.Exists(resultPath[0]))
        {
            Message response = new() {
                Command = "library-get-path-response",
                Data = resultPath[0]
            };
            
            MessageHandler.SendResponse(sender, response);
        }
    }
}