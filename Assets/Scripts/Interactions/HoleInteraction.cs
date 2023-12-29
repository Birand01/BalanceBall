using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInteraction : InteractionBase
{
    public static event Action<CanvasType> OnSwitchLevelFailUI;
    public static event Action<SoundType, bool> OnHoleInteractionSound;
    protected override void OnTriggerEnterAction(Collider other)
    {
       
       OnHoleInteractionSound?.Invoke(SoundType.BallHoleInteraction, true);
       OnSwitchLevelFailUI?.Invoke(CanvasType.LevelFailUI);
       other.transform.DOMove(this.transform.position,0.2f).SetEase(Ease.Linear);
       other.transform.DOScale(0, 0.3f).SetEase(Ease.Linear).OnComplete(()=>
       other.gameObject.SetActive(false));
    }
}
