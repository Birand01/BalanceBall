using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallPosition : MonoBehaviour
{
    private CompositeDisposable subscriptions = new CompositeDisposable();
    public static event Action<CanvasType> OnSwitchNextLevelUI;
    public static event Action<CanvasType> OnSwitchLevelFailUI;
    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            LevelIdentifier();

        })
            .AddTo(subscriptions);
    }
    private void OnDisable()
    {
        subscriptions.Clear();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    private void LevelIdentifier()
    {
        if(this.transform.position.y>=20f)
        {
            OnSwitchNextLevelUI?.Invoke(CanvasType.NextLevelUI);
        }
        if(this.transform.position.y<-1f)
        {
            OnSwitchLevelFailUI?.Invoke(CanvasType.LevelFailUI);
        }

    }
}
