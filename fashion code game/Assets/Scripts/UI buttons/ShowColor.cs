using System.Collections;
using System.Collections.Generic;
using Clothing.ClothingPresets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowColor : MonoBehaviour
{
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    public void ShowColorButton()
    {
        uiObject.SetActive(true);
    }
    
}