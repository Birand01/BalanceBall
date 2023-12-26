using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : StickMovementBase
{
    private float totalRotationAmount;
     internal float rotatePerClick;
   
    protected override void OnEnable()
    {
       
        LeftRotationButton.OnLeftRotationOfStick += StickRotation;
        RightRotationButton.OnRightRotationOfStick += StickRotation;
    }
    private void OnDisable()
    {
        LeftRotationButton.OnLeftRotationOfStick -= StickRotation;
        RightRotationButton.OnRightRotationOfStick -= StickRotation;

    }
    protected override void StickRotation(int rotationSign)
    {
        totalRotationAmount += rotatePerClick*rotationSign;
        totalRotationAmount = Mathf.Clamp(totalRotationAmount, -38, 38);
        this.transform.DORotate(new Vector3(0, 0, totalRotationAmount),easeMotionResponse).SetEase(easeType);

    }
}
