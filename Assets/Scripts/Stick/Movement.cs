using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : StickMovementBase
{
    private float totalMovementAmount;
    internal float movePerClick;
    protected override void OnEnable()
    {
        UpMovementButton.OnUpMovementOfStick += StickMovement;
        DownMovementButton.OnDownMovementOfStick += StickMovement;
       
    }

    private void OnDisable()
    {
        UpMovementButton.OnUpMovementOfStick -= StickMovement;
        DownMovementButton.OnDownMovementOfStick -= StickMovement;

    }

    protected override void StickMovement(int movementSign)
    {
        totalMovementAmount += movePerClick * movementSign;
        totalMovementAmount=Mathf.Clamp(totalMovementAmount, 0f, 20.2f);
        this.transform.DOMove(new Vector3(0, totalMovementAmount, 0), easeMotionResponse).SetEase(easeType);
    }



}
