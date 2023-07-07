using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using PhotinoNET;

namespace SpinShareClient.MessageParser;

using LibraryCache;

/// <summary>
/// A command that returns the state of a <see cref="LibraryItem"/> given a <c>fileReference</c> and <c>updateHash</c>
/// </summary>
public class CommandLibraryGetState : ICommand
{
    private LibraryCache? _libraryCache;
    
    public async Task Execute(PhotinoWindow? sender, object? data)
    {
        if (data == null) return;
        
        _libraryCache = LibraryCache.GetInstance();
        
        JObject dataItem = (JObject)data;
            
        string fileReference = dataItem.GetValue("fileReference")?.ToObject<string>() ?? "";
        string updateHash = dataItem.GetValue("updateHash")?.ToObject<string>() ?? "";

        Message response = new() {
            Command = "library-get-state-response",
            Data = _libraryCache.GetState(fileReference, updateHash)
        };
        
        await Task.Yield();

        MessageHandler.SendResponse(sender, response);
    }
}