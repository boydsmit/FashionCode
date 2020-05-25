﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MailboxLoadscene : MonoBehaviour

{
    
    bool colliding;
 
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            colliding = true;
        }
           
    }
 
  
    private void Update()
    {
        if (colliding == true && Input.GetKeyDown(KeyCode.F))
        {
            SceneManager.LoadScene("Mail_Scene");
        }
    }
}
