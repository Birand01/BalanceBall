using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private Color[] randomColors;
    [SerializeField] private GameObject holePrefab;
    private float wallLine=2;
    private float height,width;
    private MeshRenderer meshRenderer;
    private bool canContinue=false;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        height=meshRenderer.bounds.size.y;
        width=meshRenderer.bounds.size.x;
       
    }
   

    private void Start()
    {
        meshRenderer.material.color = randomColors[Random.Range(0,randomColors.Length)];
        StartCoroutine(SpawnHole());
    }

    

    private IEnumerator SpawnHole()
    {
        yield return null;
        while(wallLine<height)
        {
            for (int i = 0; i < 3; i++)
            {
                
                GameObject go = Instantiate(holePrefab);
                go.transform.position = new Vector3(Random.Range(-3, 4), wallLine, 0.98f);
                go.transform.rotation = Quaternion.Euler(90, 0, 0);
              
            }
           
            wallLine += 1;
        }   
    }
}
