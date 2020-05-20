using Newtonsoft.Json;

namespace Clothing.ClothingPresets
{
    public class ClothingData
    {
        [JsonProperty("Base")]private static string _clothingBase;
        [JsonProperty("Length")]private static string _length;
        [JsonProperty("Color")]private static string _color;

        public ClothingData(string clothingBase, string length, string color)
        {
            _clothingBase = clothingBase;
            _length = length;
            _color = color;
        }

        public string GetClothingBase()
        {
            return _clothingBase;
        }
        
        public string GetLength()
        {
            return _length;
        }

        public string GetColor()
        {
            return _color;
        }
    }
}