using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StartGame : MonoBehaviour
{

    // Update is called once per frame
    public void StartScene()
    {
        SceneManager.LoadScene("Artscene");
        Debug.Log("start");
    }
}
