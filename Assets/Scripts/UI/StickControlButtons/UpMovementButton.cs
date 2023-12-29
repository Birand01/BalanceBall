using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpMovementButton : ButtonBase
{
    public static event Action<SoundType,bool> OnUpMovementSoundOfStick;
    public static event Action<int> OnUpMovementOfStick;
    protected override void OnButtonEventHandler()
    {
        OnUpMovementSoundOfStick?.Invoke(SoundType.StickMovement,true);
        OnUpMovementOfStick?.Invoke(motionSign);
    }
}
