using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownMovementButton : ButtonBase
{
    public static event Action<int> OnDownMovementOfStick;
    protected override void OnButtonEventHandler()
    {
        Debug.Log("Down Button is pressed");
        OnDownMovementOfStick?.Invoke(-motionSign);
    }
}
