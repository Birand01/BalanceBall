using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class StickMovement : MonoBehaviour
{
    [SerializeField] private float speed=0,rotation=0;

    private Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        UpDownMovement();
        Rotation();
    }

    private void UpDownMovement()
    {
        if(Input.GetKey(KeyCode.W)) 
        {
            speed +=0.01f;
            this.transform.DOMoveY(speed, 0.5f).SetEase(Ease.Linear);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            speed -= 0.01f;
            this.transform.DOMoveY(speed, 0.5f).SetEase(Ease.Linear);
        }
    }

    private void Rotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            rotation += 0.01f;
            this.transform.DORotate(new Vector3(0,0,speed), 0.5f).SetEase(Ease.Linear);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rotation -= 0.01f;
            this.transform.DORotate(new Vector3(0, 0, speed), 0.5f).SetEase(Ease.Linear);
        }
    }
}
