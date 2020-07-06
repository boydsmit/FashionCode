using Newtonsoft.Json;

namespace Clothing.ClothingPresets
{
    public class ClothingData
    {
        [JsonProperty("Base")] private static string _clothingBase;
        [JsonProperty("Length")]private static string _length;
        [JsonProperty("Color")]private static string _color;
        [JsonProperty("Pattern")] private static string _pattern;
        [JsonProperty("PatternColor")] private static string _patternColor;

        public ClothingData(string clothingBase, string length, string color, string pattern, string patternColor)
        {
            _clothingBase = clothingBase;
            _length = length;
            _color = color;
            _pattern = pattern;
            _patternColor = patternColor;
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

        public string GetPattern()
        {
            return _pattern;
        }

        public string GetPatternColor()
        {
            return _patternColor;
        }
    }
}