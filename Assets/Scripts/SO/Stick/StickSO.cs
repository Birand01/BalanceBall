using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName ="ScriptableObjects/Stick",fileName ="Stick",order = 0)]
public class StickSO : ScriptableObject
{
    public Ease easeType;
    public float easeMotionResponseTime;
    public float rotationCoefficient, movementCoefficient;

}
