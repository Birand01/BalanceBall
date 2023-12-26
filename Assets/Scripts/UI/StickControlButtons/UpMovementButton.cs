using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMovementButton : ButtonBase
{
    public static event Action<int> OnUpMovementOfStick;
    protected override void OnButtonEventHandler()
    {
       
        OnUpMovementOfStick?.Invoke(motionSign);
    }
}
