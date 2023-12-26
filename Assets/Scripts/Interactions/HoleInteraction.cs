using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleInteraction : InteractionBase
{
    protected override void OnTriggerEnterAction(Collider other)
    {
       other.transform.DOMove(this.transform.position,0.2f).SetEase(Ease.Linear);
       other.transform.DOScale(0, 3f).SetEase(Ease.Linear).OnComplete(()=>
       other.gameObject.SetActive(false));
    }
}
