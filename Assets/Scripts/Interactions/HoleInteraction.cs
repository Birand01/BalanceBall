using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInteraction : InteractionBase
{
    public static event Action<CanvasType> OnLevelFailUI;
    protected override void OnTriggerEnterAction(Collider other)
    {
        OnLevelFailUI?.Invoke(CanvasType.LevelFailUI);
       other.transform.DOMove(this.transform.position,0.2f).SetEase(Ease.Linear);
       other.transform.DOScale(0, 3f).SetEase(Ease.Linear).OnComplete(()=>
       other.gameObject.SetActive(false));
    }
}
