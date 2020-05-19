using System.IO;
using Newtonsoft.Json;
using UnityEngine;


namespace Clothing.ClothingPresets
{
    public class PresetSaver : MonoBehaviour
    {
        private void GetPresetValues()
        {

        }

        private void WriteJsonFile(string clothingBase, string length, string color)
        {
            using (var streamWriter = File.CreateText(@""))
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
