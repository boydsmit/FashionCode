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
        var clothingPreset = new ClothingData("T-shirt","Long","#B365E5","tartan","#FFEA45");
        var madeClothing = GameObject.FindWithTag("Clothing").GetComponent<ClothingData>();

        if (clothingPreset.GetColor() == madeClothing.GetColor() && 
            clothingPreset.GetLength() == madeClothing.GetLength() &&
            clothingPreset.GetClothingBase() == madeClothing.GetClothingBase() &&
             clothingPreset.GetPattern() == madeClothing.GetPattern() &&
              clothingPreset.GetPatternColor() == madeClothing.GetPatternColor())
        {
            uiObject.SetActive(true); 
        }
            
         
        clothingPreset.GetColor();
    }


    
   
}