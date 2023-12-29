using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : StickMovementBase
{
    private float totalMovementAmount;
    internal float movePerClick;
    public static event Action<CanvasType> OnSwitchNextLevelUI;
    public static event Action<bool> OnBallInitialJump;
    public static Movement Instance {  get; private set; }
    private void Awake()
    {
        if(Instance == null)
            Instance = this;
    }
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
        totalMovementAmount=Mathf.Clamp(totalMovementAmount, 0f, 20f);       
        this.transform.DOMove(new Vector3(0, totalMovementAmount, 0), easeMotionResponse).SetEase(easeType);
        if (totalMovementAmount >= 20f)
        {
            OnSwitchNextLevelUI?.Invoke(CanvasType.NextLevelUI);
          
             
        }
    }

   


}
