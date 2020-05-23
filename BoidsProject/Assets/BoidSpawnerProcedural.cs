using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidSpawnerProcedural : MonoBehaviour
{
    public GameObject prefab;

    public float radious;

    public int numberOfBoids;

    public float frecuency;

    private float frecuencyTimer;

    public float limitTime;

    private float limitTimeTimer;

    void Start()
    {
        frecuencyTimer = 0.0f;
        limitTimeTimer = 0.0f;
    }

    void Update()
    {
        if (limitTimeTimer < limitTime)
        {
            limitTimeTimer += Time.deltaTime;

            if (frecuencyTimer >= frecuency)
            {
                for (int i = 0; i < numberOfBoids; i++)
                {
                    Instantiate(prefab, this.transform.position + Random.insideUnitSphere * radious, Random.rotation);
                }
                frecuencyTimer = 0;
            }
            else
            {
                frecuencyTimer += Time.deltaTime;
            }
        }



    }
}
