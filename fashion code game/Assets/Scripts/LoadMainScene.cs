using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMainScene : MonoBehaviour
{
    
   
    // Update is called once per frame
    
    public void LoadLevel()
    {
        SceneManager.LoadScene("Artscene");
        Debug.Log("art");
      
        
    }
    
   
}