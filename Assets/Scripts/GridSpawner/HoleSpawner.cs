using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HoleSpawner : MonoBehaviour
{
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private int numberToSpawn;
    private float wallLine=2;
    private float height, xPos;
    private MeshRenderer meshRenderer;
    private void Awake()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        height=meshRenderer.bounds.size.y;
       
    }

    private void Start()
    {
       StartCoroutine(SpawnHole());
    }
    

    private IEnumerator SpawnHole()
    {
        yield return null;
        while(wallLine<height)
        {
            for (int i = 0; i < 2; i++)
            {
                GameObject go = Instantiate(holePrefab);
                go.transform.position = new Vector3(Random.Range(-3, 4), wallLine, 0.7f);
                go.transform.rotation = Quaternion.Euler(90, 0, 0);
              
            }
           
            wallLine += 1;

        }

      
       
    }
}
