using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawner : MonoBehaviour
{
    public GameObject prefab;

    public float radious;

    public int numberOfBoids;

    void Start()
    {
        for(int i = 0; i< numberOfBoids; i++)
        {
            Instantiate(prefab, this.transform.position + Random.insideUnitSphere * radious, Random.rotation);
        }
    }

    void Update()
    {
        
    }
}
