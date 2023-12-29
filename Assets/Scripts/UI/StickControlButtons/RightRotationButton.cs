using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightRotationButton : ButtonBase
{
    public static event Action<int> OnRightRotationOfStick;
    protected override void OnButtonEventHandler()
    {
        OnRightRotationOfStick?.Invoke(-motionSign);

    }
}
