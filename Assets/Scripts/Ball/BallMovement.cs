using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMovement : MonoBehaviour
{
    private Transform jumpPosition;
    [SerializeField] private float moveSpeed,swipeSpeed;
    private Vector3 lastMousePos,newPosTransform;

    private void Awake()
    {
        jumpPosition = GameObject.FindGameObjectWithTag("JumPosition").transform;
    }
    private void OnEnable()
    {
        Movement.OnBallInitialJump += BallInitialJumPosition;
    }
    private void OnDisable()
    {
        Movement.OnBallInitialJump -= BallInitialJumPosition;
      

    }
  

    private void BallInitialJumPosition(bool state)
    {
        if (state)
        {
            this.transform.DOJump(jumpPosition.position,2,1,0.5f);
        }
    }
}
