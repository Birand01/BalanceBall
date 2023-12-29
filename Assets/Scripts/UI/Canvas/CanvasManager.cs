using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
   StickButtonControlUI,
   RushUI,
   LevelFailUI
}
public class CanvasManager : MonoBehaviour
{
    List<CanvasController> canvasControllerList;
    internal CanvasController lastActiveCanvas;
    private void Awake()
    {
        canvasControllerList = GetComponentsInChildren<CanvasController>().ToList();
        canvasControllerList.ForEach(x => x.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.StickButtonControlUI);
    }
    private void OnEnable()
    {
        HoleInteraction.OnLevelFailUI += SwitchCanvas;
        Movement.OnDisableStickMotionUI += SwitchCanvas;
    }
    private void OnDisable()
    {
        Movement.OnDisableStickMotionUI -= SwitchCanvas;
        HoleInteraction.OnLevelFailUI -= SwitchCanvas;

    }

    private void SwitchCanvas(CanvasType canvasType)
    {

        if (lastActiveCanvas != null)
        {
            lastActiveCanvas.gameObject.SetActive(false);
        }
        CanvasController desiredCanvas = canvasControllerList.Find(x => x.canvasType == canvasType);
        if (desiredCanvas != null)
        {
            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else
        {
            Debug.LogWarning("The desired canvas was not found");
        }
    }
}
