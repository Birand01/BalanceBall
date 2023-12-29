using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
public enum CameraType
{
    stickCamera,
    ballCamera
}
public class VirtualCameraManager : MonoBehaviour
{

    List<VirtualCameraController> virtualCameraControllerList;
    internal VirtualCameraController lastActiveCamera;

    private void Awake()
    {
        virtualCameraControllerList = GetComponentsInChildren<VirtualCameraController>().ToList();
        virtualCameraControllerList.ForEach(x => x.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 0);
        SwitchCamera(CameraType.stickCamera);
    }
 
    private void SwitchCamera(CameraType cameraType)
    {
        if (lastActiveCamera != null)
        {
            lastActiveCamera.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 0;
        }
        VirtualCameraController desiredCamera = virtualCameraControllerList.Find(x => x.cameraType == cameraType);
        if (desiredCamera != null)
        {
            desiredCamera.gameObject.GetComponent<CinemachineVirtualCamera>().Priority = 1;
            lastActiveCamera = desiredCamera;
        }
        else
        {
            Debug.LogWarning("The desired camera was not found");
        }
    }

}
