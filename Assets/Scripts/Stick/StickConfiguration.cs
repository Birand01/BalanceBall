using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickConfiguration : MonoBehaviour
{
    [SerializeField] private StickSO stickSO;



    private void OnEnable()
    {
        SetUpConfiguration();
    }

    private void SetUpConfiguration()
    { 
        if (stickSO != null)
        {
            this.gameObject.GetComponent<Rotation>().easeMotionResponse = stickSO.easeMotionResponseTime;
            this.gameObject.GetComponent<Rotation>().easeType = stickSO.easeType;
            this.gameObject.GetComponent<Rotation>().rotatePerClick = stickSO.rotationCoefficient;
            this.gameObject.GetComponent<Movement>().easeMotionResponse=stickSO.easeMotionResponseTime;
            this.gameObject.GetComponent<Movement>().easeType = stickSO.easeType;
            this.gameObject.GetComponent<Movement>().movePerClick = stickSO.movementCoefficient;
        }
        else
        {
            Debug.Log("StickSO can not be found");
        }
    }
}
