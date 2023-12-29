using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;
using DG.Tweening;

public abstract class StickMovementBase : MonoBehaviour
{

    private CompositeDisposable subscriptions = new CompositeDisposable();
    internal float easeMotionResponse;
    internal Ease easeType;
    private void OnDisable()
    {
        subscriptions.Clear();
    }

    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    protected virtual void StickMovement(int movementSign) { }
    protected virtual void StickRotation(int rotationSign) { }
  
    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
            StickMovement(1); 
            StickRotation(1);
           
        })
            .AddTo(subscriptions);
    }
}
