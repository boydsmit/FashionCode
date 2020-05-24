using System.Collections;
using System.Collections.Generic;
using Clothing.ClothingPresets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }

    public void OnButtonClick()
    {
        var clothingPreset = new ClothingData("Shirt","Long","#B365E5","tartan","#FFEA45");
        var madeClothing = GameObject.FindWithTag("Clothing");
        var color = ColorUtility.ToHtmlStringRGBA(madeClothing.GetComponent<SpriteRenderer>().color);
        var clothingName = madeClothing.name.Split('_');
        var pattern = GameObject.FindWithTag("Pattern");
        var patternName = "null";
        var patternColor = "null";
        
        if (pattern != null)
        {
            patternName = pattern.name.Split('_')[1].Replace("(Clone)", "");
            patternColor = ColorUtility.ToHtmlStringRGB(pattern.GetComponent<SpriteRenderer>().color);
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