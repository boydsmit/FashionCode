using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace Commands
{
    public class CommandInfo
    {
        [JsonProperty("executor")] private string _executor;
        [JsonProperty("optionsType")] private string _optionsType;
        [JsonProperty("options")] private List<string> _options;
        [JsonProperty("optionsMap")] private Dictionary<string, string> _optionsMap;

        public string GetExecutor()
        {
            return _executor;
        }

        public string GetOptionsType()
        {
            return _optionsType;
        }

        public List<string> GetOptions()
        {
            return _options;
        }

        public Dictionary<string, string> GetOptionsMap()
        {
            return _optionsMap;
        }

        public List<CommandInfo> GetAllCommandInfos(string fileName)
        {
            var commands = Resources.Load<TextAsset>(fileName);
            return JsonConvert.DeserializeObject<List<CommandInfo>>(commands.text);
        }
    }
}