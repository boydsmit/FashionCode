using Clothing.ClothingPresets;
using UnityEngine;


public class EndLevel : MonoBehaviour
{
    private readonly PresetManager _presetManager = new PresetManager();
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        var clothingPreset = _presetManager.GetPreset();
        var madeClothing = GameObject.FindWithTag("Clothing");
        var color = ColorUtility.ToHtmlStringRGB(madeClothing.GetComponent<Renderer>().material.color);
        var clothingName = madeClothing.name.Split('_');
        var pattern = GameObject.FindWithTag("Pattern");
        var patternName = "null";
        var patternColor = "null";
        
        if (pattern != null)
        {
            patternName = pattern.name.Split('_')[1].Replace("(Clone)", "");
            patternColor = ColorUtility.ToHtmlStringRGB(pattern.GetComponent<Renderer>().material.color);
        }

        if (clothingPreset.GetColor() == color && clothingPreset.GetLength() == clothingName[1] &&
            clothingPreset.GetClothingBase() == clothingName[0] && clothingPreset.GetPattern() == patternName &&
            clothingPreset.GetPatternColor() == patternColor) 
        {
            uiObject.SetActive(true); 
        }
        clothingPreset.GetColor();
    }
}