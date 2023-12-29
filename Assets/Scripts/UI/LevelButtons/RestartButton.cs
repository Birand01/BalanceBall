using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartButton : ButtonBase
{
  
    protected override void OnButtonEventHandler()
    {
       
        SceneManager.LoadScene(0);
    }

   
}
