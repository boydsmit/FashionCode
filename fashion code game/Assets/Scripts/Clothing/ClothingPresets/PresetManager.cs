using System.IO;
using Newtonsoft.Json;

namespace Clothing.ClothingPresets
{
    public class PresetManager
    {
        private ClothingData GetPreset()
        {
            ClothingData clothingData;
            
            using (var streamReader = new StreamReader("Assets/Scripts/Clothing/ClothingPreset/Preset.json"))
            {
                var json = streamReader.ReadToEnd();
                clothingData = JsonConvert.DeserializeObject<ClothingData>(json);
            }
            return clothingData;
        }

        public void WriteJsonFile(string clothingBase, string length, string color)
        {
            using (var streamWriter = File.CreateText("Assets/Scripts/Clothing/ClothingPresets/Preset.json"))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.WriteStartObject();
                jsonWriter.WritePropertyName("Base");
                jsonWriter.WriteValue(clothingBase);
                jsonWriter.WritePropertyName("Length");
                jsonWriter.WriteValue(length);
                jsonWriter.WritePropertyName("Color");
                jsonWriter.WriteValue(color);
                jsonWriter.WriteEnd();
                jsonWriter.WriteEndObject();
            }
        }
    }
}
