using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftRotationButton : ButtonBase
{
    public static event Action<int> OnLeftRotationOfStick;
    protected override void OnButtonEventHandler()
    {
       
        Debug.Log("Left Rotation button is pressed");
        OnLeftRotationOfStick?.Invoke(motionSign);
    }

  
}
