using System;
using System.Collections;
using System.Collections.Generic;
using UniRx.Triggers;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
public abstract class ButtonBase : MonoBehaviour
{
    public static event Action<SoundType, bool> OnStickButtonSound;
    private Button button;
    protected int motionSign=1;

  
    private void Awake()
    {
        button = GetComponent<Button>();
    }
   
   
    private void Start()
    {
        button.onClick.AddListener(OnButtonClickEvent);
    }

    private void OnButtonClickEvent()
    {
        OnButtonEventHandler();
        OnStickButtonSound?.Invoke(SoundType.StickMovement, true);

    }

    protected abstract void OnButtonEventHandler();
 
    protected void IsButtonInteractable(bool state)
    {
        button.interactable = state;
    }
}
