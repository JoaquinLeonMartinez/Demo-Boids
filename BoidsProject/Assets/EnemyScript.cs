using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float radious;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var boids = FindObjectsOfType<Boid>();
        var average = Vector3.zero;

        foreach (var boid in boids)
        {
            var diff = boid.transform.position - this.transform.position;
            if (diff.magnitude < radious)
            {
                //estos son los boids que estan dentro de su rango
                boid.GetComponent<BoidScaredBehaviour>().scared = true;
                
            }
        }
    }
}
