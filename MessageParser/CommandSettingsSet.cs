using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace SpinShareClient.MessageParser;

using LibraryCache;

public class CommandSettingsSet : ICommand
{
    private SettingsManager? _settingsManager;
    
    public async Task<object> Execute(object data)
    {
        _settingsManager = SettingsManager.GetInstance();

        JArray dataArray = (JArray)data;
        foreach (var jToken in dataArray)
        {
            JObject dataItem = (JObject)jToken;
            
            string? key = dataItem.GetValue("key")?.ToObject<string>();
            object? value = dataItem.GetValue("value")?.ToObject<object>();
            
            if (key != null && value != null)
            {
                Console.WriteLine("[SettingsSetCommand] Writing Setting: " + key);
            
                _settingsManager.Set(key, value);
            }
        }

        Message response = new() {
            Command = "settings-set-response",
            Data = _settingsManager.GetFull()
        };

        return response;
    }
}