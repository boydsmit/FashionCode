namespace Clothing.ClothingPresets
{
    public class ClothingPreset
    {
        private static string _clothingBase;
        private static string _length;
        private static string _color;

        public ClothingPreset(string clothingBase, string length, string color)
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