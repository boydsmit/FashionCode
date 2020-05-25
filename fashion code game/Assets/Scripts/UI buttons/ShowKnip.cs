using System.Collections;
using System.Collections.Generic;
using Clothing.ClothingPresets;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShowKnip : MonoBehaviour
{
    public GameObject uiObject;

    void Start()
    {
        uiObject.SetActive(false);
    }

    public void ShowKnipButton()
    {
        uiObject.SetActive(true);
    }
    
}