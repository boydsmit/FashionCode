using System.Collections;
using System.Collections.Generic;
using Clothing.ClothingPresets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowNaai : MonoBehaviour
{
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    public void ShowNaaiButton()
    {
        uiObject.SetActive(true);
    }
    
}