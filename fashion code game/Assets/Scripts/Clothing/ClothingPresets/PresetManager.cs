using System.IO;
using Newtonsoft.Json;

namespace Clothing.ClothingPresets
{
    public class PresetManager
    {
        public ClothingData GetPreset()
        {
            ClothingData clothingData;
            
            using (var streamReader = new StreamReader("Assets/Scripts/Clothing/ClothingPreset/Preset.json"))
            {
                var json = streamReader.ReadToEnd();
                clothingData = JsonConvert.DeserializeObject<ClothingData>(json);
            }
            return clothingData;
        }

        public void WriteJsonFile(string clothingBase, string length, string color, string pattern, string patternColor)
        {
            using (var streamWriter = File.CreateText("Assets/Scripts/Clothing/ClothingPresets/Preset.json"))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("base");
                jsonWriter.WriteValue(clothingBase);
                jsonWriter.WritePropertyName("length");
                jsonWriter.WriteValue(length);
                jsonWriter.WritePropertyName("color");
                jsonWriter.WriteValue(color);
                jsonWriter.WritePropertyName("pattern");
                jsonWriter.WriteValue(pattern);
                jsonWriter.WritePropertyName("patternColor");
                jsonWriter.WriteValue(patternColor);
                jsonWriter.WriteEnd();
                jsonWriter.WriteEndObject();
            }
        }
    }
}
