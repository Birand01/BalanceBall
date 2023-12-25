using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
public abstract class ButtonBase : MonoBehaviour
{
    private CompositeDisposable subscriptions = new CompositeDisposable();
    private Button button;

  
    private void Awake()
    {
        button = GetComponent<Button>();
    }
    protected virtual void OnEnable()
    {
        StartCoroutine(Subscribe());
    }
    protected virtual void OnDisable()
    {

        subscriptions.Clear();
    }

    private void Start()
    {
        button.onClick.AddListener(OnButtonClickEvent);
    }

    private void OnButtonClickEvent()
    {
        
    }

    protected virtual IEnumerator Subscribe()
    {
        yield return null;

        this.UpdateAsObservable().Subscribe(x =>
        {
          
        })
            .AddTo(subscriptions);
    }
    public virtual void UpDownMovement() { }
    public virtual void LeftRightRotation() { }
    protected void IsButtonInteractable(bool state)
    {
        button.interactable = state;
    }
}
