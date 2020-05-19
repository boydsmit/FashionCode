using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
    public GameObject uiObject;
    void Start()
    {
        uiObject.SetActive(false);
    }
   
    // Update is called once per frame
    
    public void ShowDone()
    {
        // SceneManager.LoadScene("Artscene");
        Debug.Log("art");
        uiObject.SetActive(true);
        
    }
    
   
}