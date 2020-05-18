using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndLevel : MonoBehaviour
{
  
    void Start()
    {

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene("Artscene");
        Debug.Log("art");
    }
    
   
}